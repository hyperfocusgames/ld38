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
					return "Missle Shot";
			}
		}

    public override string description {
			get {
					return "Changes your bullets into slower explosive missiles - <i>Only one chance for this!</i>";
			}
		}
}
