using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
	private const int patrolChangeChance = 1;
	public float aimAheadTime = .5f;
	public float stopDist = 3f;
	public float viewDist = 5f;
	public bool stunable = true;

	protected SurfaceEntity entity;
	protected static SurfaceEntity playerEntity;
	protected ShipData ship;
	protected static Planet planet;
	protected Vector3 patrolTarget;

	protected void setup()
	{
		if(entity == null)
		{
			entity = GetComponent<SurfaceEntity>();
		}
		if(ship == null)
		{
			ship = GetComponent<ShipData>();
		}
		if(planet == null)
		{
			planet = GameObject.FindObjectOfType<Planet>();
		}
		if(playerEntity == null && PlayerData.player != null)
		{
			playerEntity = PlayerData.player.GetComponent<SurfaceEntity>();
		}
	}

	protected virtual void FixedUpdate ()
	{
		if(playerEntity == null || entity == null || ship == null || planet == null)
		{
			setup();
		}
		else if(!ship.isStunned())
		{
			if(playerEntity != null && PlayerData.player.isAlive)
			{
				Vector3 player = PlayerData.player.transform.position;

				Vector3 toPlayer = player - transform.position;

				// If player is within view range, try to attack player
				if(toPlayer.magnitude < viewDist)
				{
					followTarget(player, toPlayer);
				}
				else
				{
					patrol();
				}
			}
			else
			{
				// If player is missing, just patrol. Use in menu screen?
				patrol();
			}
		}
	}

	protected void followTarget(Vector3 target, Vector3 toTarget)
	{
		// If player is further than stop distance, move closer
		if(toTarget.magnitude >= stopDist )
		{
			Vector3 prediction = target + (playerEntity.body.velocity * aimAheadTime);	// Aim where player will be in the future
			Vector3 toPrediction = prediction - transform.position;
			entity.body.AddForce(toPrediction.normalized * ship.MoveSpeed, ForceMode.Acceleration);
		}
		// Stop and face target
		else
		{
			entity.transform.LookAt(target, transform.position - planet.transform.position);
		}

		// Constantly fire when able
		ship.shoot();
	}

	protected void patrol()
	{
		if(patrolTarget == null || Random.Range(0, 100) < patrolChangeChance)
		{
			patrolTarget = new Vector3(Random.Range(-planet.radius, planet.radius), Random.Range(-planet.radius, planet.radius), Random.Range(-planet.radius, planet.radius));
		}
		Vector3 toTarget = transform.position - patrolTarget;
		entity.body.AddForce(toTarget.normalized * ship.MoveSpeed, ForceMode.Acceleration);
	}
}
