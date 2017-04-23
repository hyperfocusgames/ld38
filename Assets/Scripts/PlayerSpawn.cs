using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSpawn : TerrainProp {

	void Start() {
		PlayerData.player.transform.position = transform.position;
	}

}
