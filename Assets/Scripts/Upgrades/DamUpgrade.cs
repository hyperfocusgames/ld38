using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.player.damUpgrade();
    }
}
