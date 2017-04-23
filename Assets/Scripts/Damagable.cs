using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
	ShipData ship;

	void Awake()
	{
		ship = GetComponent<ShipData>();
	}

	public void damage(int dam)
	{
		ship.dealDamage(dam);
		if(ship.hp <= 0)
		{
			if(tag == "Enemy")
			{
				GameManager.killEnemy();
			}
			Destroy(gameObject);
		}
	}
}
