using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.shieldUpgrade();
    }

		public override string title {
			get {
					return "Max Shields";
			}
		}

    public override string description {
			get {
					return "Upgrades your ship's max shields by " + PlayerData.ShieldUpgradeAmount;
			}
		}
}
