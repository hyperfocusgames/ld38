using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : Damager
{
	public float radius = 5f;

	private void explode()
	{
		Collider[] cols = Physics.OverlapSphere(transform.position, radius);
		foreach(Collider col in cols)
		{
			col.GetComponent<Damagable>().damage(damage);
		}
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider col)
	{
		explode();
	}
}
