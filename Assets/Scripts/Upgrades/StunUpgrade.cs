using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.stunUpgrade();
    }

		public override string title {
			get {
					return "Stun Time";
			}
		}

    public override string description {
			get {
					return "Increases the time you stun enemies on collision by " + PlayerData.StunUpgradeAmount;
			}
		}
}
