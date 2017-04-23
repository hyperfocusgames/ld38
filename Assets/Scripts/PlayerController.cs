using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SurfaceEntity), typeof(ShipData))]
public class PlayerController : MonoBehaviour {

	SurfaceEntity entity;

	void Awake() {
		entity = GetComponent<SurfaceEntity>();
<<<<<<< HEAD
=======
		ship = GetComponent<ShipData>();
	}
	
	void Start() {
>>>>>>> origin
		entity.body.velocity = transform.forward; // give it a tiny push to fix the camera shit (this is a game jam ok)
	}

	void FixedUpdate() {
		Vector3 up = CameraRig.instance.transform.up;
		Vector3 right = CameraRig.instance.transform.right;
<<<<<<< HEAD
		entity.body.AddForce(up * Input.GetAxisRaw("Vertical") * PlayerData.player.MoveSpeed);
		entity.body.AddForce(right * Input.GetAxisRaw("Horizontal") * PlayerData.player.MoveSpeed);
=======
		Vector3 input
			= up * Input.GetAxisRaw("Vertical")
			+ right * Input.GetAxisRaw("Horizontal");
		input.Normalize();
		entity.body.AddForce(input * moveForce);
>>>>>>> origin
		
		if(Input.GetAxisRaw("Fire1") > 0)
		{
			PlayerData.player.shoot();
		}
	}

}
