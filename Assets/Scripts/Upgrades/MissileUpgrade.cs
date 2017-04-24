using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileUpgrade : Upgrade
{
    public MissileUpgrade()
    {
        limited = true;
    }

    public override void activate()
    {
        PlayerData.player.missileUpgrade();
    }

		public override string title {
			get {
					return "Missile Shot";
			}
		}

    public override string description {
			get {
					return "Boom goes the... laser?";
			}
		}
}
