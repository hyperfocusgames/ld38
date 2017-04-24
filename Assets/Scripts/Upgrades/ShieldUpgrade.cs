using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUpgrade : Upgrade
{

		public ShieldUpgrade() {
			limited = true;
		}

    public override void activate()
    {
        PlayerData.shieldUpgrade();
    }

		public override string title {
			get {
					return "Max Shields";
			}
		}

    public override string description {
			get {
					return "Remember, always use convection\n- <i>Increase max shields by " + PlayerData.ShieldUpgradeAmount + "</i>";
			}
		}
}
