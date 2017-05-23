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
		lastHitTime = -ship.stats.recoveryDelay;
	}

	public void damage(float dam)
	{
		if ((Time.time - lastHitTime) > ship.stats.recoveryDelay) {
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
