using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamUpgrade : Upgrade
{

		public DamUpgrade() {
			limited = true;
		}

    public override void activate()
    {
        PlayerData.damUpgrade();
    }

		public override string title {
			get {
					return "Damage";
			}
		}

    public override string description {
			get {
					return "What's yours?\n- <i>Increase damage dealt by " + PlayerData.DamUpgradeAmount + "</i>";
			}
		}
}
