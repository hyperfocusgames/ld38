﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpGate : TerrainProp {

	public Color flashColor = Color.white;
	public float flashDuration = 1;
	public GameObject portalEffect;

	public bool isOpen { get; set; }

	void Awake() {
		isOpen = false;
	}

	void OnTriggerEnter(Collider col) {
		if (isOpen && col.GetComponentInParent<PlayerData>() != null) {
			LevelManager.instance.NextPlanet();
			if (ScreenFlash.instance) {
				ScreenFlash.instance.Flash(flashColor, flashDuration);
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
