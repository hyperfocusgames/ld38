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

	public virtual void activate(GameObject projectile, float speed, float damage, bool damPlayer, bool damEnemy)
	{
		//Debug.Log(projectile.name);
		GameObject go = Instantiate(projectile, transform.position, transform.rotation);

		Damager dam = go.GetComponent<Damager>();
		if(dam != null)
		{
			dam.damage = damage;
			dam.damPlayer = damPlayer;
			dam.damEnemy = damEnemy;
		}

		SurfaceEntity entity = go.GetComponent<SurfaceEntity>();
		entity.hoverHeight = parentEntity.hoverHeight;

		Projectile proj = go.GetComponent<Projectile>();
		if(proj != null)
		{
			proj.speed = speed;
		}
	}
}
