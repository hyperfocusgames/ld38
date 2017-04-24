using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
	public int damage = 1;
	public bool damPlayer = true;
	public bool damEnemy = false;

	void OnTriggerEnter(Collider col)
	{
		if((damPlayer && col.tag == "Player") ||
		 	(damEnemy && col.tag == "Enemy") ||
			 (col.tag != "Player" && col.tag != "Enemy"))
		{
			Debug.Log(col.name);
			Damagable dam = col.GetComponent<Damagable>();
			if(dam != null)
			{
				dam.damage(damage);
			}
			Destroy(gameObject);
		}
	}
}
