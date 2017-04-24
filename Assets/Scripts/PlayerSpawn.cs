using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSpawn : TerrainProp {

	void OnPlanetStart() {
		PlayerData player = PlayerData.player;
		player.transform.position = transform.position;
		player.Spawn();
	}

}
