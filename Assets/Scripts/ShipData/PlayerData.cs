using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerData : ShipData
{
	public static PlayerData player;
	
	private static float 	moveSpeedUpgradeAmount = 1f;
	private static int 		hpUpgradeAmount = 1;
	private static int		shieldUpgradeAmount = 1;
	private static float	shieldRechargeUpgradeAmount = .25f;
	private static float 	rofUpgradeAmount = .05f;
	private static int 		damUpgradeAmount = 2;
	private static float	stunUpgradeAmount = .1f;
	
	private static int numMoveSpeedUpgrades = 0;
	private static int numHPUpgrades = 0;
	private static int numShieldUpgrades = 0;
	private static int numShieldRechargeUpgrades = 0;
	private static int numROFUpgrades = 0;
	private static int numDamUpgrades = 0;
	private static int numStunUpgrades = 0;
	public Gun[] upgradeGuns;	// Guns that will be enabled after the gun upgrade
	public float gunUpgradeROFPenalty = 0.8f;
	public GameObject missile;	// The projectile that will be fired after the missile upgrade

	public ParticleSystem lowHealthEffect;
	private bool godMode = false;
	public Color damageFlashColor = Color.red;
	public GameObject deathUI;

	public bool isAlive {
		get {
			return gameObject.activeSelf;
		}
	}

 	protected override void Awake()
	{
		DontDestroyOnLoad(this);
		player = this;

		numMoveSpeedUpgrades = 0;
		numHPUpgrades = 0;
		numShieldUpgrades = 0;
		numShieldRechargeUpgrades = 0;
		numROFUpgrades = 0;
		numDamUpgrades = 0;
		numStunUpgrades = 0;

		HasGunUpgrade = false;

		foreach(Gun g in upgradeGuns)
		{
			if(g != null)
			{
				g.gameObject.SetActive(false);
			}
		}

		base.Awake();
	}

	protected void Update() {
		if (lowHealthEffect != null) {
			if (hp <= 1) {
				if (lowHealthEffect.isStopped){
					lowHealthEffect.Play();
				}
			}
			else {
				lowHealthEffect.Stop();
			}
		}
	}
	

	public static bool HasGunUpgrade { get; private set; }
	public static int NumMoveSpeedUpgrades { get { return numMoveSpeedUpgrades; } }
    public static int NumHPUpgrades { get { return numHPUpgrades; } }
    public static int NumShieldUpgrades { get { return numShieldUpgrades; } }
    public static int NumShieldRechargeUpgrades { get { return numShieldRechargeUpgrades; } }
    public static int NumROFUpgrades { get { return numROFUpgrades; } }
    public static int NumDamUpgrades { get { return numDamUpgrades; } }
    public static int NumStunUpgrades { get { return numStunUpgrades; } }

	new public float MoveSpeed
	{
		get{ return moveSpeed + (moveSpeedUpgradeAmount * numMoveSpeedUpgrades); }
	}
	public override int MaxHP
	{
		get{ return base.MaxHP + (hpUpgradeAmount * numHPUpgrades); }
	}
	public override int MaxShield
	{
		get{ return base.MaxShield + (shieldUpgradeAmount * numShieldUpgrades); }
	}
	public override float ShieldRechargeTime
	{
		get{ return base.ShieldRechargeTime - (shieldRechargeUpgradeAmount * numShieldRechargeUpgrades); }
	}
	public override float RateOfFire
	{
		get{ return (base.RateOfFire - (rofUpgradeAmount * numROFUpgrades) * (HasGunUpgrade ? gunUpgradeROFPenalty : 1)); }
	}
	public override int Damage
	{
		get{ return base.Damage + (damUpgradeAmount * numDamUpgrades); }
	}
	public override float StunTime
	{
		get{ return base.StunTime + (stunUpgradeAmount * numStunUpgrades); }
	}

    public static float MoveSpeedUpgradeAmount { get { return moveSpeedUpgradeAmount; } }
    public static int HpUpgradeAmount { get { return hpUpgradeAmount; } }
    public static int ShieldUpgradeAmount { get { return shieldUpgradeAmount; } }
    public static float ShieldRechargeUpgradeAmount { get { return shieldRechargeUpgradeAmount; } }
    public static float ROFUpgradeAmount { get { return rofUpgradeAmount; } }
    public static int DamUpgradeAmount { get { return damUpgradeAmount; } }
    public static float StunUpgradeAmount { get { return stunUpgradeAmount; } }


    public static void moveSpeedUpgrade()
	{
		numMoveSpeedUpgrades++;
	}
	public static void hpUpgrade()
	{
		numHPUpgrades++;
		player.hp ++;
	}
	public static void shieldUpgrade()
	{
		numShieldUpgrades++;
	}
	public static void shieldRechargeUpgrade()
	{
		numShieldRechargeUpgrades++;
	}
	public void heal()
	{
		hp = MaxHP;
	}
	public static void rofUpgrade()
	{
		numROFUpgrades++;
	}
	public static void damUpgrade()
	{
		numDamUpgrades++;
	}
	public static void stunUpgrade()
	{
		numStunUpgrades++;
	}
	public void gunUpgrade()
	{
		foreach(Gun g in upgradeGuns)
		{
			g.gameObject.SetActive(true);
		}
		findGuns();
		HasGunUpgrade = true;
	}
	public void missileUpgrade()
	{
		projectile = missile;
	}

	public void Spawn(Planet planet) {
		gameObject.SetActive(true);
		entity.planet = planet;
	}

	void OnDeath() {
		if (lowHealthEffect != null) {
			lowHealthEffect.transform.SetParent(null, true);
			lowHealthEffect.Stop();
		}
		UI.instance.ShowDeathScreen();
		gameObject.SetActive(false);
	}

	public void GodMode()
	{
		godMode = !godMode;
	}

	public override void dealDamage(int amt)
	{
		base.dealDamage(amt);
		if(godMode && hp <= 0)
		{
			hp = 1;
		}
		if(hp <= 0 && deathUI != null)
		{
			Instantiate(deathUI, Vector3.zero, Quaternion.identity);
		}
	}

	void OnDamageTaken(int damage) {
		ScreenFlash.instance.Flash(damageFlashColor, damageRecoveryTime);
	}

	void OnPlanetEnd() {
		gameObject.SetActive(false);
	}

}
