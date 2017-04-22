using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SurfaceEntity : MonoBehaviour {

	public Planet planet { get; set; }

	public float hoverHeight = 0;
	public bool faceVelocity = true;
	public float accelerationRollFactor = 1;
	public float accelerationSmoothing = 5;

	public Rigidbody body { get; private set; }

	Vector3 oldVelocity;
	Vector3 smoothAcceleration;

	void Awake() {
		planet = FindObjectOfType<Planet>();
		body = GetComponent<Rigidbody>();
		oldVelocity = body.velocity;
	}

	void FixedUpdate() {
		Vector3 acceleration = (body.velocity - oldVelocity) / Time.fixedDeltaTime;
		smoothAcceleration = Vector3.Lerp(smoothAcceleration, acceleration, Time.fixedDeltaTime * accelerationSmoothing);
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
				Vector3 up = pos;
				up += smoothAcceleration * accelerationRollFactor;
				transform.LookAt(transform.position + velocity, up);
			}
		}
		oldVelocity = body.velocity;
	}


}
