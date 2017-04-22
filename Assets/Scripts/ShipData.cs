using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipData : MonoBehaviour
{
    public float moveSpeed = 100f;             	// Force to be applied in movement
	public int baseHP = 1;						// Starting HP
	public int hp;								// Current HP
    public GameObject projectile;               // Projectile to fire
    private float rateOfFire = .5f;             // Base rate of fire (This is divided by the number of guns to get effective ROF)
    private float projectileSpeed = 1f;         // Speed of projectile when fired
    private int damage = 1;                     // Damage to be done by projectile
    public bool damPlayer = false;				// Should the player be damaged by this?
	public bool damEnemy = true;				// Should enemies be damaged by this?

	protected Gun[] guns;						// Array of all guns
	protected float lastShot = float.MinValue;	// Time of last shot
	protected int gunNum = 0;                   // Next gun to shoot

    public float MoveSpeed {
		get{ return moveSpeed; }
		set{ moveSpeed = value; }
	}

    public float RateOfFire {
		get{ return rateOfFire; }
		set{ rateOfFire = value; }
	}

    public float ProjectileSpeed {
		get{ return projectileSpeed; }
		set{ projectileSpeed = value; }
	}

    public int Damage {
		get{ return damage; }
		set{ damage = value; }
	}

	public int MaxHP {
		get { return baseHP; }
		set { baseHP = value; }
	}

    protected void Awake()
	{
		Debug.Log("Awake");

		findGuns();
		hp = MaxHP;
	}

	// Find all active guns and store them in guns
	public void findGuns()
	{
		guns = gameObject.GetComponentsInChildren<Gun>();
	}

	// Fire a shot if cooldown from the next active gun
	public void shoot()
	{
		// Cooled down
		if(cooledDown())
		{
			guns[gunNum].activate(projectile, projectileSpeed, Damage, damPlayer, damEnemy);	// Shoot
			gunNum = (gunNum + 1) % guns.Length;	// Go to next gun
			lastShot = Time.time;					// Set last shot to now
		}
	}

	protected bool cooledDown()
	{
		return Time.time - lastShot > RateOfFire / guns.Length;
	}
}
