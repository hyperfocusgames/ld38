using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.player.moveSpeedUpgrade();
    }
}
