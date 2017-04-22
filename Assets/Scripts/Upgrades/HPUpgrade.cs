using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.hpUpgrade();
    }

    public override string toString()
    {
        return "Upgrades your ship's HP by " + PlayerData.HpUpgradeAmount;
    }
}
