using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROFUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.rofUpgrade();
    }

    public override string toString()
    {
        return "Upgrades your ship's rate of fire by " + PlayerData.ROFUpgradeAmount;
    }
}
