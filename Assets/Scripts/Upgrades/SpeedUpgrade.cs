﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.moveSpeedUpgrade();
    }

    public override string toString()
    {
        return "Upgrades your ship's speed by " + PlayerData.MoveSpeedUpgradeAmount;
    }
}
