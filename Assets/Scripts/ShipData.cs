using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipData : MonoBehaviour
{
    public float moveSpeed = 50f;             			// Force to be applied in movement
	public int baseHP = 1;								// Starting HP
	public int hp;										// Current HP
	public int baseShield = 1;							// Starting shield	
	public int shield;									// Current shield
	public float baseShieldRechargeTime = 5f;			// Time for shield to recharge
    public GameObject projectile;               		// Projectile to fire
    public float rateOfFire = .5f;             			// Base rate of fire (This is divided by the number of guns to get effective ROF)
    private float projectileSpeed = 10f;        		// Speed of projectile when fired
    private int damage = 1;                     		// Damage to be done by projectile
    public bool damPlayer = false;						// Should the player be damaged by this?
	public bool damEnemy = true;						// Should enemies be damaged by this?

	public float damageRecoveryTime = 0;


	protected Gun[] guns;								// Array of all guns
	protected float lastShot = float.MinValue;			// Time of last shot
	protected bool cooledDown = true;					// Can this shoot again?
	protected int gunNum = 0;                   		// Next gun to shoot
	protected float startStunTime = float.MinValue;		// Time when stun was started
	protected float stunTime = 0f;						// Amount of time to stun for
	protected bool stunned = false;						// Is this stunned?
	private float lastHitTime = float.MinValue;		// Time of last damage taken
	protected SurfaceEntity entity;						// Surface entity attached to this
	protected Shield shieldObject;					// Shield attatched to this

    public virtual float MoveSpeed {
		get{ return moveSpeed; }
		set{ moveSpeed = value; }
	}

    public virtual float RateOfFire {
		get{ return rateOfFire; }
		set{ rateOfFire = value; }
	}

    public virtual float ProjectileSpeed {
		get{ return projectileSpeed; }
		set{ projectileSpeed = value; }
	}

    public virtual int Damage {
		get{ return damage; }
		set{ damage = value; }
	}

	public virtual int MaxHP {
		get { return baseHP; }
		set { baseHP = value; }
	}
	public virtual int MaxShield {
		get { return baseShield; }
		set { baseHP = value; }
	}
	public virtual float ShieldRechargeTime {
		get { return baseShieldRechargeTime; }
		set { baseShieldRechargeTime = value; }
	}
	public virtual float StunTime {
		get { return stunTime; }
		set { stunTime = value; }
	}

  	protected virtual void Awake()
	{
		findGuns();
		hp = MaxHP;
		shield = MaxShield;
		entity = GetComponent<SurfaceEntity>();
		shieldObject = GetComponentInChildren<Shield>();
	}

	void FixedUpdate()
	{
		rechargeShield();
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
		if(CooledDown() && guns.Length > 0)
		{
			guns[gunNum].activate(projectile, projectileSpeed + entity.body.velocity.magnitude, Damage, damPlayer, damEnemy);	// Shoot
			gunNum = (gunNum + 1) % guns.Length;	// Go to next gun
			lastShot = Time.time;					// Set last shot to now
			cooledDown = false;
		}
	}

	protected bool CooledDown()
	{
		if(!cooledDown)
		{
			cooledDown = Time.time - lastShot > RateOfFire / guns.Length;
		}
		return cooledDown;
	}

	public bool isStunned()
	{
		if(stunned)
		{
			stunned = (Time.time - startStunTime) <= stunTime;
		}
		return stunned;
	}

	public void stun(float time)
	{
		stunTime = time;
		startStunTime = Time.time;
	}

	public void dealDamage(int amt)
	{
		lastHitTime = Time.time;

		rechargeShield();

		if(shield - amt < 0)
		{
			amt -= shield;
			shield = 0;
			hp -= amt;
			BroadcastMessage("OnDamageTaken", amt, SendMessageOptions.DontRequireReceiver);
		}
		else
		{
			shield -= amt;
		}

		if(shield <= 0)
		{
			if(shieldObject != null)
			{
				shieldObject.Break();
			}
		}
	}

	public void rechargeShield()
	{
		if(MaxShield > shield && Time.time - lastHitTime > ShieldRechargeTime)
		{
			Debug.Log("recharge");
			shield++;
			lastHitTime = Time.time;	// Just set this to now so it resets recharge cooldown
			if(shieldObject != null)
			{
				shieldObject.Reform();
			}
		}
	}
}
