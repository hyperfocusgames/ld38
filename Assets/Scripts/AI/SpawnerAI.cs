using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAI : AI
{
	protected override void FixedUpdate()
	{
		if(playerEntity == null || entity == null || ship == null || planet == null)
		{
			setup();
		}
		else if(!ship.isStunned())
		{
			patrol();
			ship.shoot();
		}
	}
}
