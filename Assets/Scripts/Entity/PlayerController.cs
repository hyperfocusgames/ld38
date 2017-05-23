using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	SurfaceEntity entity;

	void Awake() {
		entity = GetComponent<SurfaceEntity>();
		entity.faceVelocity = false;
		entity.body.constraints = RigidbodyConstraints.FreezeRotation;
	}
	
	void Start() {
		entity.body.velocity = transform.forward; // give it a tiny push to fix the camera shit (this is a game jam ok)
	}

	void Update() {
		CameraRig rig = CameraRig.instance;
		Vector3 faceDirection = Input.mousePosition - new Vector3(
			rig.cam.pixelWidth / 2,
			rig.cam.pixelHeight / 2,
			-
			0
		);
		faceDirection
			= rig.transform.right * faceDirection.x
			+ rig.transform.up * faceDirection.y;
		transform.LookAt(transform.position + faceDirection.normalized, entity.normal + entity.smoothAcceleration * entity.accelerationRollFactor);
	}

	void FixedUpdate() {
		// Vector3 up = CameraRig.instance.transform.up;
		// Vector3 right = CameraRig.instance.transform.right;
		// Vector3 input
		// 	= up * Input.GetAxisRaw("Vertical")
		// 	+ right * Input.GetAxisRaw("Horizontal");
		// input.Normalize();
		// float moveSpeed = PlayerData.player.MoveSpeed;
		// entity.body.AddForce(input * moveSpeed, ForceMode.Acceleration);
		if(Input.GetButton("Fire1")) {
			float moveSpeed = PlayerData.player.stats.moveSpeed;
			entity.body.AddForce(transform.forward * moveSpeed, ForceMode.Acceleration);
		}
		if(Input.GetButton("Fire2")) {
			PlayerData.player.shoot();
		}
	}

}
