using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public void activate(GameObject projectile, float speed, int damage, bool damPlayer, bool damEnemy)
	{
		GameObject go = Instantiate(projectile, transform.position, Quaternion.Euler(transform.forward));
		Damager dam = go.AddComponent<Damager>();
		dam.damage = damage;
		dam.damPlayer = damPlayer;
		dam.damEnemy = damEnemy;
	}
}
