using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpGate : TerrainProp {

	void OnTriggerEnter(Collider col) {
		if (col.GetComponentInParent<PlayerData>() != null) {
			LevelManager.instance.NextPlanet();
			if (WarpFlash.instance) {
				WarpFlash.instance.Flash();
			}
		}
	}

}
