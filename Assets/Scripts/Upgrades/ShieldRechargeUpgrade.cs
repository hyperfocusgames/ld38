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

    public override string toString()
    {
        return "<b>Shield Recharge Upgrade:<\b> Upgrades your ship's shield recharge timer by " + PlayerData.ShieldRechargeUpgradeAmount + " - There are a limited number of these!";
    }
}
