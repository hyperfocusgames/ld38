using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.hpUpgrade();
    }

    public override string title {
			get {
					return "Max Health";
			}
		}

    public override string description {
			get {
					return "Upgrades your ship's max HP by " + PlayerData.HpUpgradeAmount;
			}
		}
}
