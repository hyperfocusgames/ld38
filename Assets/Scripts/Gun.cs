using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public void activate(GameObject projectile, float speed, int damage, bool damPlayer, bool damEnemy)
	{
		GameObject go = Instantiate(projectile, transform.position, Quaternion.Euler(transform.forward));
		Damager dam = go.AddComponent<Damager>();
		SurfaceEntity entity = go.AddComponent<SurfaceEntity>();
		entity.hoverHeight = GetComponentInParent<SurfaceEntity>().hoverHeight;

		// ***** None of these work *****
		entity.body.AddForce(speed * transform.up, ForceMode.Impulse);
		entity.body.AddForce(speed * transform.forward, ForceMode.Impulse);
		entity.body.AddForce(speed * transform.right, ForceMode.Impulse);
		// ******************************

		dam.damage = damage;
		dam.damPlayer = damPlayer;
		dam.damEnemy = damEnemy;
	}
}
