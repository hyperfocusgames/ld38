using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planet : MonoBehaviour {

	public Transform surfaceModel;
	public float radius = 1;

	void Awake() {
	}

	void OnValidate() {
		if (surfaceModel) {
			surfaceModel.localScale = Vector3.one * radius * 2;
		}
	}

}
