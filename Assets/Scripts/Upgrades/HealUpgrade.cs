using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUpgrade : Upgrade
{
    public override void activate()
    {
        PlayerData.player.heal();
    }

		public override string title {
			get {
					return "Heal";
			}
		}

    public override string description {
			get {
					return "Restore your ship to full health";
			}
		}
}
