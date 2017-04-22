using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SurfaceEntity : MonoBehaviour {

	public Planet planet { get; set; }

	public float hoverHeight = 0;
	public Rigidbody body { get; private set; }
	public Vector3 normal { get { return transform.localPosition.normalized; } }

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
		// try to rotate to maintain correct up normal
		Vector3 oldNormal = transform.up;
		float angleDelta = Vector3.Angle(oldNormal, normal);
		Vector3 axis = Vector3.Cross(oldNormal, normal);
		transform.Rotate(axis, angleDelta);
		// maintain proper distance from planet surface
		Vector3 position = transform.localPosition;
		position = position.normalized * (planet.radius + hoverHeight);
		transform.localPosition = position;
	}


}
