using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyAfter : MonoBehaviour {

	public float time = 1;

	float t;

	void Awake() {
		t = time;
	}

	void Update() {
		t -= Time.deltaTime;
		if (t <= 0) {
			Destroy(gameObject);
		}
	}

}
