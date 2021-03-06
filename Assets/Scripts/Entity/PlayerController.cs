using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	SurfaceEntity entity;

	void Awake() {
		entity = GetComponent<SurfaceEntity>();
	}
	
	void Start() {
		entity.body.velocity = transform.forward; // give it a tiny push to fix the camera shit (this is a game jam ok)
	}

	void Update() {
		if(Input.GetButtonDown("GodMode"))
		{
			PlayerData.player.GodMode();
		}
	}

	void FixedUpdate() {
		Vector3 up = CameraRig.instance.transform.up;
		Vector3 right = CameraRig.instance.transform.right;
		Vector3 input
			= up * Input.GetAxisRaw("Vertical")
			+ right * Input.GetAxisRaw("Horizontal");
		input.Normalize();
		float moveSpeed = PlayerData.player.MoveSpeed;
		entity.body.AddForce(input * moveSpeed, ForceMode.Acceleration);
		
		if(Input.GetAxisRaw("Fire1") > 0)
		{
			PlayerData.player.shoot();
		}
	}

}
