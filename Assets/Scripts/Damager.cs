using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
	public int damage = 1;
	public bool damPlayer = true;
	public bool damEnemy = false;

	void OnTriggerEnter(Collider col) {
		if ((damPlayer && col.CompareTag("Player"))
			|| (damEnemy && col.CompareTag("Enemy"))
			|| (!col.CompareTag("Player") && !col.CompareTag("Enemy"))
			) {
			Damagable dam = col.GetComponent<Damagable>();
			if(dam != null)
			{
				dam.damage(damage);
			}
			Destroy(gameObject);
		}
	}
}
