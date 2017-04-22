using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipData : MonoBehaviour
{
	public GameObject projectile;				// Projectile to fire
	public float rateOfFire = .5f;				// Base rate of fire
	public float projectileSpeed = 1f;			// Speed of projectile when fired
	public int damage = 1;						// Damage to be done by projectile
	public bool damPlayer = false;
	public bool damEnemy = true;
	public Gun[] guns;							// Array of all guns

	private float lastShot = float.MinValue;	// Time of last shot
	private int gunNum = 0;						// Next gun to shoot

	void Start()
	{
		findGuns();
	}

	// Find all active guns and store them in guns
	private void findGuns()
	{
		guns = gameObject.GetComponentsInChildren<Gun>();
	}

	// Fire a shot if cooldown from the next active gun
	public void shoot()
	{
		// Cooled down
		if(Time.time - lastShot > rateOfFire)
		{
			guns[gunNum].activate(projectile, projectileSpeed, damage, damPlayer, damEnemy);	// Shoot
			gunNum = (gunNum + 1) % guns.Length;	// Go to next gun
			lastShot = Time.time;					// Set last shot to now
		}
	}

}
