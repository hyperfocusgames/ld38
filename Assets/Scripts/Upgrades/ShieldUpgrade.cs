using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.shieldUpgrade();
    }

    public override string toString()
    {
        return "<b>Shield Upgrade:<\b> Upgrades your ship's max shields by " + PlayerData.ShieldUpgradeAmount;
    }
}
