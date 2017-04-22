using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	SurfaceEntity entity;
	public float moveForce = 100;

	void Awake() {
		entity = GetComponent<SurfaceEntity>();
	}

	void FixedUpdate() {
		Vector3 up = CameraRig.instance.transform.up;
		Vector3 right = CameraRig.instance.transform.right;
		entity.body.AddForce(up * Input.GetAxisRaw("Vertical") * moveForce, ForceMode.Force);
		entity.body.AddForce(right * Input.GetAxisRaw("Horizontal") * moveForce, ForceMode.Force);
	}

}
