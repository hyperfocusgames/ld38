using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRechargeUpgrade : Upgrade
{
    public ShieldRechargeUpgrade()
    {
        limited = true;
    }
    public override void activate()
    {
        PlayerData.shieldRechargeUpgrade();
    }

		public override string title {
			get {
					return "Shield Recharge";
			}
		}

    public override string description {
			get {
					return "Upgrades your ship's shield recharge timer by " + PlayerData.ShieldRechargeUpgradeAmount + " - <i>There are a limited number of these!</i>";
			}
		}
}
