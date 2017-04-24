﻿using System.Collections;
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
        return "<b>HP Upgrade:<\b> Upgrades your ship's max HP by " + PlayerData.HpUpgradeAmount;
    }
}
