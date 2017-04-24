using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UpgradesDeck
{
	public static int numUpgradesToDraw = 3;

	private static List<Upgrade> deck;

	public static bool isInitialized {
		get {
			return deck != null;
		}
	}

	public static void InitializeDeck() {
		deck = new List<Upgrade>();
		
		AddToDeck(new DamUpgrade(), 2);
		AddToDeck(new ShieldUpgrade(), 2);
		AddToDeck(new SpeedUpgrade(), 3);
		AddToDeck(new HPUpgrade(), 4);
		AddToDeck(new GunUpgrade(), 1);
		AddToDeck(new ROFUpgrade(), 5);
		AddToDeck(new MissileUpgrade(), 1);
		AddToDeck(new ShieldRechargeUpgrade(), 4);

		AddToDeck(new HealUpgrade(), 1);
	}

	public static void AddToDeck(Upgrade upgrade, int count = 1) {
		for (int i = 0; i < count; i ++) {
			deck.Add(upgrade);
		}
	}

	const int maxTries = 100;

	public static Upgrade[] draw() {
		List<Upgrade> upgrades = new List<Upgrade>();
		Upgrade upgrade = null;
		int tries = 0;
		while (deck.Count > 0 && upgrades.Count < numUpgradesToDraw && tries < maxTries) {
			int r = Random.Range(0, deck.Count);
			upgrade = deck[r];
			if (upgrades.Contains(upgrade)) {
				tries ++;
			}
			else {
				tries = 0;
				if(upgrade.limited) {
					deck.RemoveAt(r);
				}
				upgrades.Add(upgrade);
			}
		}
		if (upgrades.Count == 0) {
			upgrades.Add(new NoUpgrade());
		}
		return upgrades.ToArray();
	}

	public static void insert(Upgrade u)
	{
		deck.Add(u);
	}
}
