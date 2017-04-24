using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUpgrade : Upgrade
{

		public HPUpgrade() {
			limited = true;
		}

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
					return "Who says I don't have heart?\n- <i> Increase max health by " + PlayerData.HpUpgradeAmount + "</i>";
			}
		}
}
