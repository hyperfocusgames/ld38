using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
	public float aimAheadTime = 1f;
	public float stopDist = 3f;
	public bool stunable = true;

	protected SurfaceEntity entity;
	protected SurfaceEntity playerEntity;
	protected ShipData ship;
	protected Planet planet;

	private void setup()
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

	void Update ()
	{
		if(playerEntity == null || entity == null || ship == null || planet == null)
		{
			setup();
		}
		else if(!ship.isStunned())
		{
			Vector3 player = PlayerData.player.transform.position;

			Vector3 toPlayer = player - transform.position;

			// If player is further than stop distance, move closer
			if(toPlayer.magnitude >= stopDist)
			{
				Vector3 target = player + (playerEntity.body.velocity * aimAheadTime);	// Aim where player will be in the future
				Vector3 toTarget = target - transform.position;
				entity.body.AddForce(toTarget.normalized * ship.moveSpeed);
			}
			// Stop and face target
			else
			{
				entity.transform.LookAt(player, transform.position - planet.transform.position);
			}

			// Constantly fire when able
			ship.shoot();
		}
	}
}
