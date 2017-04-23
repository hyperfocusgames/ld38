using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.damUpgrade();
    }

    public override string toString()
    {
        return "Upgrades your ship's damage by " + PlayerData.DamUpgradeAmount;
    }
}
