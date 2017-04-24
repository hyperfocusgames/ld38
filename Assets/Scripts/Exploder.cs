﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : Damager
{
	public float radius = 1f;
	Damagable dam;

	void Awake()
	{
		dam = GetComponent<Damagable>();
	}

	public void explode()
	{
		// do death things
		BroadcastMessage("OnDeath", SendMessageOptions.DontRequireReceiver);

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
		
		dam.dieEffect();
	}

	void OnTriggerEnter(Collider col)
	{
		if((damPlayer && col.tag == "Player") ||
		 	(damEnemy && col.tag == "Enemy"))
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
