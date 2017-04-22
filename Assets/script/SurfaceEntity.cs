using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SurfaceEntity : MonoBehaviour {

	public Planet planet { get; set; }

	public float hoverHeight = 0;
	public Rigidbody body { get; private set; }

	void Awake() {
		planet = GetComponentInParent<Planet>();
		body = GetComponent<Rigidbody>();
	}

	void Update() {
		if (planet != null) {
			AlignPosition();
		}
	}

	void AlignPosition() {
			Vector3 position = transform.localPosition;
			position = position.normalized * (planet.radius + hoverHeight);
			transform.localPosition = position;
	}


}
