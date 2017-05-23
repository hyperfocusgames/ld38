using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipData : MonoBehaviour {

	public ShipStatCollection stats;

	public float hp;										// Current HP
	public float shield;									// Current shield
	public GameObject projectile;               		// Projectile to fire
	public float rateOfFire = .5f;             			// Base rate of fire (This is divided by the number of guns to get effective ROF)
	private float projectileSpeed = 10f;        		// Speed of projectile when fired
	public bool damPlayer = false;						// Should the player be damaged by this?
	public bool damEnemy = true;						// Should enemies be damaged by this?
	public AudioClip shootSound;
	public float shootSoundPitchOffset = 0.05f;
	public GameObject explosion;						// Effect to play on death

	protected Gun[] guns;								// Array of all guns
	protected float lastShot = float.MinValue;			// Time of last shot
	protected bool cooledDown = true;					// Can this shoot again?
	protected int gunNum = 0;                   		// Next gun to shoot
	protected float startStunTime = float.MinValue;		// Time when stun was started
	protected float stunTime = 0f;						// Amount of time to stun for
	protected bool stunned = false;						// Is this stunned?
	private float lastHitTime = float.MinValue;			// Time of last damage taken
	public SurfaceEntity entity { get; private set; }						// Surface entity attached to this
	protected AudioSource audioSource;					// Audio Source attached to this
	protected Shield shieldObject;						// Shield attatched to this

	float baseAudioPitch;

	protected virtual void Awake() {
		findGuns();
		hp = stats.maxHealth;
		shield = stats.maxShields;
		entity = GetComponent<SurfaceEntity>();
		shieldObject = GetComponentInChildren<Shield>();
		audioSource = GetComponent<AudioSource> ();
		if (audioSource != null) {
			baseAudioPitch = audioSource.pitch;
		}
		lastShot = Time.time - Random.value * stats.fireDelay;
	}

	void FixedUpdate() {
		rechargeShield();
	}

	// Find all active guns and store them in guns
	public void findGuns() {
		guns = gameObject.GetComponentsInChildren<Gun>();
	}

	// Fire a shot if cooldown from the next active gun
	public void shoot() {
		// Cooled down
		if(guns.Length > 0 && projectile != null && CooledDown()) {
			guns[gunNum].activate(projectile, projectileSpeed + entity.body.velocity.magnitude, stats.damage, damPlayer, damEnemy);	// Shoot
			gunNum = (gunNum + 1) % guns.Length;	// Go to next gun
			lastShot = Time.time;					// Set last shot to now
			cooledDown = false;
			if (audioSource != null) {
				audioSource.pitch = baseAudioPitch * (1 + Random.Range(- shootSoundPitchOffset, shootSoundPitchOffset));
				audioSource.PlayOneShot(shootSound);
			}
		}
	}

	protected bool CooledDown() {
		if(!cooledDown) {
			cooledDown = Time.time - lastShot > stats.fireDelay / guns.Length;
		}
		return cooledDown;
	}

	public bool isStunned() {
		if(stunned) {
			stunned = (Time.time - startStunTime) <= stunTime;
		}
		return stunned;
	}

	public void stun(float time) {
		stunTime = time;
		startStunTime = Time.time;
	}

	public virtual void dealDamage(float amt) {
		lastHitTime = Time.time;

		rechargeShield();

		if (shield > 0) {
			shieldObject.Hit();
		}

		if(shield - amt < 0) {
			amt -= shield;
			shield = 0;
			hp -= amt;
			BroadcastMessage("OnDamageTaken", amt, SendMessageOptions.DontRequireReceiver);
		}
		else {
			shield -= amt;
		}

		if(shield <= 0) {
			if(shieldObject != null) {
			shieldObject.Break();
			}
		}
	}

	public void rechargeShield() {
		if(stats.maxShields > shield && Time.time - lastHitTime > stats.shieldRechargeDelay) {
			shield++;
			lastHitTime = Time.time;	// Just set this to now so it resets recharge cooldown
			if(shieldObject != null) {
				shieldObject.Reform();
			}
		}
	}
}
