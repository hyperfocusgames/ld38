using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.moveSpeedUpgrade();
    }

		public override string title {
			get {
					return "Speed";
			}
		}

    public override string description {
			get {
					return "Upgrades your ship's speed by " + PlayerData.MoveSpeedUpgradeAmount;
			}
		}
}
