using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : ShipData
{
	public static PlayerData player;

	public float moveSpeedUpgradeAmount = 10f;
	public int hpUpgradeAmount = 1;
	public float rofUpgradeAmount = 1;
	public int damUpgradeAmount = 1;
	private int numMoveSpeedUpgrades = 1;
	private int NumHPUpgrades = 1;
	private int numROFUpgrades = 1;
	private int numDamUpgrades = 1;
	public Gun[] upgradeGuns;

	new protected void Awake()
	{
		base.Awake();

		player = this;

		foreach(Gun g in upgradeGuns)
		{
			g.gameObject.SetActive(false);
		}
	}

	new protected float MoveSpeed
	{
		get{ return moveSpeed + (moveSpeedUpgradeAmount * numMoveSpeedUpgrades); }
	}

	new protected int MaxHP
	{
		get{ return base.MaxHP + (hpUpgradeAmount * NumHPUpgrades); }
	}

	new protected float RateOfFire
	{
		get{ return base.RateOfFire - (rofUpgradeAmount * numROFUpgrades); }
	}

	new protected float Damage
	{
		get{ return base.Damage + (damUpgradeAmount * numDamUpgrades); }
	}

	public void rofUpgrade()
	{
		numROFUpgrades++;
	}

	public void damUpgrade()
	{
		numDamUpgrades++;
	}

	public void moveSpeedUpgrade()
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
