using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SurfaceEntity), typeof(ShipData))]
public class PlayerController : MonoBehaviour {

	SurfaceEntity entity;
	private ShipData ship;

	void Awake() {
		entity = GetComponent<SurfaceEntity>();
		ship = GetComponent<ShipData>();
	}

	void FixedUpdate() {
		Vector3 up = CameraRig.instance.transform.up;
		Vector3 right = CameraRig.instance.transform.right;
		entity.body.AddForce(up * Input.GetAxisRaw("Vertical") * ship.MoveSpeed);
		entity.body.AddForce(right * Input.GetAxisRaw("Horizontal") * ship.MoveSpeed);
		
		if(Input.GetAxisRaw("Fire1") > 0)
		{
			ship.shoot();
		}
	}

}
