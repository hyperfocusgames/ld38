using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SurfaceEntity : MonoBehaviour {

	public Planet planet { get; set; }
	public Vector3 velocity { get; set; } 

	public float hoverHeight = 0;

	void Awake() {
		planet = FindObjectOfType<Planet>();
		velocity = Vector3.up * 5;
	}

	void Update() {
		if (planet != null) {
			Vector3 pos = transform.position - planet.transform.position;
			// make sure velocity is tangent to planet surface
			float speed = velocity.magnitude;
			velocity = Vector3.ProjectOnPlane(velocity, pos).normalized * speed;
			// apply velocity
			Vector3 oldPos = pos;
			pos += velocity * Time.deltaTime;
			// make sure distance is correct
			pos = pos.normalized * (planet.radius + hoverHeight);
			transform.position = planet.transform.position + pos;
		}
	}


}
