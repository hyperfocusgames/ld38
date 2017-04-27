using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAI : AI
{
	protected override void FixedUpdate()
	{
		if(setup() && !ship.isStunned())
		{
			patrol();
			ship.shoot();
		}
	}
}
