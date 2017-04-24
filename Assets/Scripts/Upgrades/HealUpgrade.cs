using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.player.heal();
    }

    public override string toString()
    {
        return "<b>Heal:<\b> restores your ship to full health";
    }
}
