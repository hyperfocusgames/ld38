using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SurfaceEntity), typeof(ShipData))]
public class PlayerController : MonoBehaviour {

	SurfaceEntity entity;

	void Awake() {
		entity = GetComponent<SurfaceEntity>();
	}
	
	void Start() {
		entity.body.velocity = transform.forward; // give it a tiny push to fix the camera shit (this is a game jam ok)
	}

	void FixedUpdate() {
		Vector3 up = CameraRig.instance.transform.up;
		Vector3 right = CameraRig.instance.transform.right;
		entity.body.AddForce(up * Input.GetAxisRaw("Vertical") * PlayerData.player.MoveSpeed);
		entity.body.AddForce(right * Input.GetAxisRaw("Horizontal") * PlayerData.player.MoveSpeed);

		
		if(Input.GetAxisRaw("Fire1") > 0)
		{
			PlayerData.player.shoot();
		}
	}

}
