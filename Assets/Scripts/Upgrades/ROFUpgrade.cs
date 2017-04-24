using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROFUpgrade : Upgrade
{

		public ROFUpgrade() {
			limited = true;
		}

    public override void activate()
    {
        PlayerData.rofUpgrade();
    }

		public override string title {
			get {
					return "Rate of Fire";
			}
		}

    public override string description {
			get {
					return "Seriously, don't hurt yourself\n- <i>Decrease time between shots by " + PlayerData.ROFUpgradeAmount + " seconds</i>";
			}
		}
}
