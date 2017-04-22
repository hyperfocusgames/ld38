using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.player.gunUpgrade();
    }
}
