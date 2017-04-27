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
	protected Planet planet;
	protected Vector3 patrolTarget;
	protected bool ready = false;

	protected bool setup()
	{
		// Only run if not ready
		if(!ready)
		{
			bool wasReady = true;
			if(entity == null)
			{
				setupEntity();
				wasReady = false;
			}
			if(ship == null)
			{
				setupShip();
				wasReady = false;
			}
			if(playerEntity == null)
			{
				setupPlayerEntity();
				wasReady = false;
			}
			if(planet == null)
			{
				setupPlanet();
				wasReady = false;
			}

			ready = wasReady;
		}
		return ready;
	}
	protected void setupEntity()
	{
		entity = GetComponent<SurfaceEntity>();
	}
	protected void setupShip()
	{
		ship = GetComponent<ShipData>();
	}
	protected void setupPlayerEntity()
	{
		if(PlayerData.player != null)
		{
			playerEntity = PlayerData.player.Entity;
		}
	}
	protected void setupPlanet()
	{
		planet = LevelManager.instance.planet;
	}

	protected virtual void FixedUpdate ()
	{
		if(setup() && !ship.isStunned() && PlayerData.player.isAlive)
		{
			if(PlayerData.player.isAlive)
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
					defaultBehavior();
				}
			}
			else
			{
				defaultBehavior();
			}
		}

	}

	protected virtual void followTarget(Vector3 target, Vector3 toTarget)
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

	protected virtual void patrol()
	{
		if(patrolTarget == Vector3.zero || Random.Range(0, 100) < patrolChangeChance)
		{
			float r = planet.radius;
			patrolTarget = new Vector3(Random.Range(-r, r), Random.Range(-r, r), Random.Range(-r, r));
		}
		Vector3 toTarget = transform.position - patrolTarget;
		entity.body.AddForce(toTarget.normalized * ship.MoveSpeed, ForceMode.Acceleration);
	}

	protected virtual void defaultBehavior()
	{
		if(entity != null && ship != null && planet != null)
		{
			patrol();
		}
	}
}
