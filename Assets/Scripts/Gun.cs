using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	protected SurfaceEntity parentEntity;
	void Awake()
	{
		parentEntity = GetComponentInParent<SurfaceEntity>();
	}

	public virtual void activate(GameObject projectile, float speed, int damage, bool damPlayer, bool damEnemy)
	{
		GameObject go = Instantiate(projectile, transform.position, transform.rotation);

		Damager dam = go.GetComponent<Damager>();
		dam.damage = damage;
		dam.damPlayer = damPlayer;
		dam.damEnemy = damEnemy;

		SurfaceEntity entity = go.GetComponent<SurfaceEntity>();
		entity.hoverHeight = parentEntity.hoverHeight;

		go.GetComponent<Projectile>().speed = speed;
	}
}
