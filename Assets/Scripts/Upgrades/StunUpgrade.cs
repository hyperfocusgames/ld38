using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.stunUpgrade();
    }

    public override string toString()
    {
        return "<b>Stun Upgrade:<\b> Increases the time you stun enemies on collision by " + PlayerData.StunUpgradeAmount;
    }
}
