using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
	protected const float aimAheadTime = .5f;

	public float stopDist = 3f;
	public bool stunable = true;

	protected SurfaceEntity entity;
	protected SurfaceEntity playerEntity;
	protected ShipData ship;
	protected Planet planet;

	void Awake()
	{
		entity = GetComponent<SurfaceEntity>();
		ship = GetComponent<ShipData>();
		planet = GameObject.FindObjectOfType<Planet>();
	}

	void Update ()
	{
		if(!ship.isStunned())
		{
			if(playerEntity == null)
			{
				if(PlayerData.player != null)
				{
					playerEntity = PlayerData.player.GetComponent<SurfaceEntity>();
				}
			}
			else
			{
				Vector3 target = PlayerData.player.transform.position + (playerEntity.body.velocity * aimAheadTime);

				Vector3 toPlayer = target - transform.position;

				// If player is further than stop distance, move closer
				if(toPlayer.magnitude >= stopDist)
				{
					entity.body.AddForce(toPlayer.normalized * ship.moveSpeed);
				}
				// Stop and face target
				else
				{
					entity.transform.LookAt(target, planet.transform.position - transform.position);
				}

				// Constantly fire when able
				ship.shoot();
			}
		}
	}
}
