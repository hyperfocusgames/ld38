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
			Die();
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
			Destroy(Instantiate(ship.explosion, transform.position, transform.rotation), ship.explosionTime);
		}
	}
}
