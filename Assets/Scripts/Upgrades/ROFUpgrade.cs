using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROFUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.rofUpgrade();
    }

		public override string title {
			get {
					return "Rate of Fire";
			}
		}

    public override string description {
			get {
					return "Upgrades your ship's rate of fire by " + PlayerData.ROFUpgradeAmount;
			}
		}
}
