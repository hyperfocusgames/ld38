using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : Upgrade
{
		public SpeedUpgrade() {
			limited = true;
		}

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
					return "Now were cooking with glass!\n- <i>Increase flight speed by " + PlayerData.MoveSpeedUpgradeAmount + " ...speed units?</i>";
			}
		}
}
