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
		Debug.Log("Collision : " + col.gameObject.name);
		if((damPlayer && col.tag == "Player") ||
		 	(damEnemy && col.tag == "Enemy"))
		{
			col.GetComponent<Damagable>().damage(damage);
		}
	}
}
