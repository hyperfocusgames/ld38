using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Revolve : MonoBehaviour {

	public float rotationSpeed = 60;

	void Update() {
		Vector3 euler = transform.eulerAngles;
		euler.y = Time.time * rotationSpeed;
		transform.eulerAngles = euler;
	}

}
