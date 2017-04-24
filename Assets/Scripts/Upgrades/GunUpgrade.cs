using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUpgrade : Upgrade
{
    public GunUpgrade()
    {
        limited = true;
    }

    public override void activate()
    {
        PlayerData.player.gunUpgrade();
    }

		public override string title {
			get {
					return "Multi Shot";
			}
		}

    public override string description {
			get {
					return "Gives you more guns, allowing you to shoot faster - <i>Only one chance for this!</i>";
			}
		}

}
