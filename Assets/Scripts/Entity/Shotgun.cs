using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
	protected const int numShots = 5;
	protected const float timeout = 1f;
	protected const float angleRange = 20f;
	public override void activate(GameObject projectile, float speed, float damage, bool damPlayer, bool damEnemy)
	{
		for(int i = 0; i < numShots; i++)
		{
			GameObject go = Instantiate(projectile, transform.position, Quaternion.Euler(transform.forward + new Vector3(0, 0, angleRange)));

			go.GetComponent<Projectile>().timeout = timeout;

			Damager dam = go.GetComponent<Damager>();
			dam.damage = damage;
			dam.damPlayer = damPlayer;
			dam.damEnemy = damEnemy;

			SurfaceEntity entity = go.GetComponent<SurfaceEntity>();
			entity.hoverHeight = parentEntity.hoverHeight;

			go.GetComponent<Projectile>().speed = speed;
		}
	}
}
