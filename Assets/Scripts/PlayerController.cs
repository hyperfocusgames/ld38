using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private ShipData ship;

	void Start()
	{
		ship = GetComponent<ShipData>();
	}

	void Update()
	{
		if(Input.GetAxisRaw("Fire1") > 0)
		{
			ship.shoot();
		}

		Vector2 dirInput;	// Direction of movement input
		dirInput.x = Input.GetAxis("Horizontal");
		dirInput.y = Input.GetAxis("Vertical");
	}
}
