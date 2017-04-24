using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : Damager
{
	public float radius = 1f;

	private void explode()
	{
		Collider[] cols = Physics.OverlapSphere(transform.position, radius);
		foreach(Collider col in cols)
		{
			if((damPlayer && col.tag == "Player") ||
		 		(damEnemy && col.tag == "Enemy"))
			{
				Damagable dam = col.GetComponent<Damagable>();
				if(dam != null)
				{
					col.GetComponent<Damagable>().damage(damage);
				}
			}
		}
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider col)
	{
		if((damPlayer && col.tag == "Player") ||
		 	(damEnemy && col.tag == "Enemy") ||
			 (col.tag != "Player" && col.tag != "Enemy"))
		{
			explode();
		}
	}
	void OnCollisionEnter(Collision col)
	{
		if((damPlayer && col.collider.tag == "Player") ||
		 	(damEnemy && col.collider.tag == "Enemy"))
		{
			explode();
		}
	}
}
