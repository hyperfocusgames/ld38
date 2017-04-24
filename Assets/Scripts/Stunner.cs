using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunner : MonoBehaviour
{
	public float stunTime = .5f;
	public bool stunPlayer = true;
	public bool stunEnemy = false;

	void OnTriggerEnter(Collider col)
	{
		if((stunPlayer && col.tag == "Player") ||
		 	(stunEnemy && col.tag == "Enemy"))
		{
			col.GetComponent<ShipData>().stun(stunTime);
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if((stunPlayer && col.collider.tag == "Player") ||
		 	(stunEnemy && col.collider.tag == "Enemy"))
		{
			col.collider.GetComponent<ShipData>().stun(stunTime);
		}
	}
}
