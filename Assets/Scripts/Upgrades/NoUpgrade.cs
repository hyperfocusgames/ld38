using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoUpgrade : Upgrade
{
    public override void activate() {}
    

		public override string title {
			get {
					return "No Upgrade";
			}
		}

    public override string description {
			get {
					return "There aren't any left!";
			}
		}
}
