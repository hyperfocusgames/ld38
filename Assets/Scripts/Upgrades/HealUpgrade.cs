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
					return "There's nothing a little tape can't fix\n- <i>Heal to full</i>";
			}
		}
}
