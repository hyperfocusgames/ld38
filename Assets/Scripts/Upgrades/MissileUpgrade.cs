using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileUpgrade : Upgrade
{
    public MissileUpgrade()
    {
        limited = true;
    }

    public override void activate()
    {
        PlayerData.player.missileUpgrade();
    }

    public override string toString()
    {
        return "<b>Missile-Shot:<\b> Changes your bullets into slower explosive missiles - <b>Only one chance for this!<\b>";
    }
}
