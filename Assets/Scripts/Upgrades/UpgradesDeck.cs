using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UpgradesDeck
{
	public class UpgradeCard
	{
		Upgrade upgrade;	// Upgrade to be applied
		int amount;			// Number of this upgrade in the deck (less than 0 is infinite)

		public UpgradeCard(Upgrade u, int a)
		{
			upgrade = u;
			amount = a;
		}
	}

	static List<UpgradeCard> deck;

	static UpgradesDeck()
	{
		deck.Add(new UpgradeCard(new GunUpgrade(), 1));
		deck.Add(new UpgradeCard(new ROFUpgrade(), -1));
		deck.Add(new UpgradeCard(new SpeedUpgrade(), -1));
		deck.Add(new UpgradeCard(new DamUpgrade(), -1));
	}
}
