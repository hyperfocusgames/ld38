using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{

	ShipData ship;

	float lastHitTime;

	void Awake()
	{
		ship = GetComponent<ShipData>();
		lastHitTime = -ship.damageRecoveryTime;
	}

	public void damage(int dam)
	{
		if ((Time.time - lastHitTime) > ship.damageRecoveryTime) {
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
		Exploder exploder = GetComponent<Exploder>();
		if(exploder != null)
		{
			exploder.explode();
		}
		else
		{
			dieEffect();
		}
	}

	public void dieEffect()
	{
		if(ship.explosion != null)
		{
			Instantiate(ship.explosion, transform.position, transform.rotation);
		}
	}
}
