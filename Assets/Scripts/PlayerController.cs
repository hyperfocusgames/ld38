using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	SurfaceEntity entity;
	private ShipData ship;
	public float moveForce = 100;

	void Awake() {
		entity = GetComponent<SurfaceEntity>();
		ship = GetComponent<ShipData>();
	}

	void FixedUpdate() {
		Vector3 up = CameraRig.instance.transform.up;
		Vector3 right = CameraRig.instance.transform.right;
		entity.body.AddForce(up * Input.GetAxisRaw("Vertical") * moveForce);
		entity.body.AddForce(right * Input.GetAxisRaw("Horizontal") * moveForce);
		
		if(Input.GetAxisRaw("Fire1") > 0)
		{
			ship.shoot();
		}
	}

}
