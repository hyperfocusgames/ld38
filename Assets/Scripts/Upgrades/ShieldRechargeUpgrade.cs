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
					return "Overclocking? Sounds pretty safe to me\n- <i>Decrease shield recharge time by " + PlayerData.ShieldRechargeUpgradeAmount + " seconds</i>";
			}
		}
}
