using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planet : MonoBehaviour {

	public Transform surfaceModel;
	public float radius = 1;
	public float radiusVariance = 0.5f;
	public Color backgroundColor = Color.black;

	void Awake() {
		radius += Random.Range(-radiusVariance, radiusVariance);
		surfaceModel.localScale = Vector3.one * radius * 2;
	}

	void OnValidate() {
		if (surfaceModel) {
			surfaceModel.localScale = Vector3.one * radius * 2;
		}
	}

}
