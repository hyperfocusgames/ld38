using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerData : ShipData
{
	public static PlayerData player;

	public static float 	moveSpeedUpgradeAmount = 10f;
    private static int 		hpUpgradeAmount = 1;
    public static float 	rofUpgradeAmount = 1;
	public static int 		damUpgradeAmount = 1;
	private static int 		numMoveSpeedUpgrades = 1;
	private static int 		NumHPUpgrades = 1;
	private static int 		numROFUpgrades = 1;
	private static int 		numDamUpgrades = 1;
	public Gun[] upgradeGuns;

 	protected override void Awake()
	{
		DontDestroyOnLoad(this);

		player = this;

		foreach(Gun g in upgradeGuns)
		{
			g.gameObject.SetActive(false);
		}
		base.Awake();
	}

	new protected float MoveSpeed
	{
		get{ return moveSpeed + (moveSpeedUpgradeAmount * numMoveSpeedUpgrades); }
	}

	new protected int MaxHP
	{
		get{ return base.MaxHP + (HpUpgradeAmount * NumHPUpgrades); }
	}

	new protected float RateOfFire
	{
		get{ return base.RateOfFire - (rofUpgradeAmount * numROFUpgrades); }
	}

	new protected float Damage
	{
		get{ return base.Damage + (damUpgradeAmount * numDamUpgrades); }
	}

    public static float MoveSpeedUpgradeAmount { get { return moveSpeedUpgradeAmount; } }
    public static int HpUpgradeAmount { get { return hpUpgradeAmount; } }
    public static int ROFUpgradeAmount { get { return hpUpgradeAmount; } }
    public static int DamUpgradeAmount { get { return hpUpgradeAmount; } }


    public static void moveSpeedUpgrade()
	{
		numDamUpgrades++;
	}

	public static void hpUpgrade()
	{
		NumHPUpgrades++;
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

	public void gunUpgrade()
	{
		foreach(Gun g in upgradeGuns)
		{
			g.gameObject.SetActive(true);
		}
		findGuns();
	}

}
