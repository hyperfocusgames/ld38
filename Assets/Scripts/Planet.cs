using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planet : MonoBehaviour {

	public float radius;

	void Awake() {
	}

	void OnValidate() {
		transform.localScale = Vector3.one * radius * 2;
	}

}
