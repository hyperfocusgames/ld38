using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
	public float damage = 1;
	public bool damPlayer = true;
	public bool damEnemy = false;
	public AnimationCurve distanceFallOff = AnimationCurve.Linear(0, 1, 1, 1);

	Projectile projectile;

	void Awake() {
		projectile = GetComponent<Projectile>();
	}

	void OnTriggerEnter(Collider col) {
		if ((damPlayer && col.CompareTag("Player"))
			|| (damEnemy && col.CompareTag("Enemy"))
			|| (!col.CompareTag("Player") && !col.CompareTag("Enemy"))
			) {
			Damagable dam = col.GetComponent<Damagable>();
			if(dam != null) {
				float damage = (float) this.damage * distanceFallOff.Evaluate(projectile.distance);
				dam.damage((int) Mathf.Ceil(damage));
			}
			Destroy(gameObject);
		}
	}
}
