using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : ShipData {

	public static int livingCount { get; set; }

	void OnEnable() {
		livingCount ++;
	}

	void OnDisable() {
		livingCount --;
	}

	void OnDeath() {
		Destroy(gameObject);
	}
}
