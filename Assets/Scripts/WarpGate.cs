using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpGate : TerrainProp {

	void Awake() {
		AttachToPlanet(GetComponentInParent<Planet>());
	}

	void OnTriggerEnter(Collider col) {
		if (col.GetComponentInParent<PlayerData>() != null) {
			LevelManager.instance.NextPlanet();
		}
	}

}
