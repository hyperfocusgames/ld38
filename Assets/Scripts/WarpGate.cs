using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpGate : TerrainProp {

	public GameObject portalEffect;

	public bool isOpen { get; set; }

	void Awake() {
		isOpen = false;
	}

	void OnTriggerEnter(Collider col) {
		if (isOpen && col.GetComponentInParent<PlayerData>() != null) {
			LevelManager.instance.NextPlanet();
			if (WarpFlash.instance) {
				WarpFlash.instance.Flash();
			}
		}
	}

	void Update() {
		isOpen = EnemyData.livingCount == 0;
		if (portalEffect != null) {
			portalEffect.SetActive(isOpen);
		}
	}

}
