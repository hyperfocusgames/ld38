using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.damUpgrade();
    }

		public override string title {
			get {
					return "Damage";
			}
		}

    public override string description {
			get {
					return "Upgrades your ship's damage by " + PlayerData.DamUpgradeAmount;
			}
		}
}
