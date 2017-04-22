using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class SurfaceEntity : MonoBehaviour {

	public Planet planet { get; set; }

	public float hoverHeight = 0;
	public bool faceVelocity = true;

	public Rigidbody body { get; private set; }

	void Awake() {
		planet = FindObjectOfType<Planet>();
		body = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		if (planet != null) {
			Vector3 pos = transform.position - planet.transform.position;
			// make sure velocity is tangent to planet surface
			Vector3 velocity = body.velocity;
			float speed = velocity.magnitude;
			velocity = Vector3.ProjectOnPlane(velocity, pos).normalized * speed;
			body.velocity = velocity;
			// make sure distance is correct
			pos = pos.normalized * (planet.radius + hoverHeight);
			transform.position = planet.transform.position + pos;
			if (faceVelocity) {
				body.constraints = RigidbodyConstraints.FreezeRotation;
				transform.LookAt(transform.position + velocity, pos);
			}
		}
	}


}
