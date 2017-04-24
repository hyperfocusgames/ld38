using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissleSpin : MonoBehaviour {

	public float rollSpeed = 45;

	Rigidbody body;

	void Awake() {
		body = GetComponentInParent<Rigidbody>();
	}

	void Update() {
		Vector3 euler = transform.localEulerAngles;
		euler.z += Time.deltaTime * rollSpeed * body.velocity.magnitude;
		transform.localEulerAngles = euler;
	}

}
