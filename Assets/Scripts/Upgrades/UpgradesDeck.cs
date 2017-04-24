using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UpgradesDeck
{
	public static int numUpgradesToDraw = 3;

	private static List<Upgrade> deck;

	static UpgradesDeck()
	{
		deck = new List<Upgrade>();

		deck.Add(new GunUpgrade());
		deck.Add(new MissileUpgrade());
		
		deck.Add(new ROFUpgrade());
		deck.Add(new SpeedUpgrade());
		deck.Add(new DamUpgrade());
		deck.Add(new HPUpgrade());
		deck.Add(new HealUpgrade());
		deck.Add(new StunUpgrade());
		deck.Add(new ShieldUpgrade());

		deck.Add(new ShieldRechargeUpgrade());
		deck.Add(new ShieldRechargeUpgrade());
		deck.Add(new ShieldRechargeUpgrade());
		deck.Add(new ShieldRechargeUpgrade());
	}

	public static Upgrade draw()
	{
		int r = Random.Range(0, deck.Count);
		Upgrade u = deck[r];
		if(u.limited)
		{
			deck.RemoveAt(r);
		}
		return u;
	}

	public static void insert(Upgrade u)
	{
		deck.Add(u);
	}
}
