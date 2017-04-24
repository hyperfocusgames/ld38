using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{

	public float recoveryTime;
	ShipData ship;

	float lastHitTime;

	void Awake()
	{
		lastHitTime = -recoveryTime;
		ship = GetComponent<ShipData>();
	}

	public void damage(int dam)
	{
		if ((Time.time - lastHitTime) > recoveryTime) {
			lastHitTime = Time.time;
			ship.dealDamage(dam);
			if(ship.hp <= 0)
			{
				Die();
			}
		}
	}

	public void Die() {
		// do death things
		BroadcastMessage("OnDeath", SendMessageOptions.DontRequireReceiver);
	}
}
