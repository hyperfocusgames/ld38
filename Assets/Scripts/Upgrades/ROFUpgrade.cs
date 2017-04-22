using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROFUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.player.rofUpgrade();
    }
}
