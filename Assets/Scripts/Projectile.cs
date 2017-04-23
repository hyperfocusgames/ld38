using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public Vector3 force;
	SurfaceEntity entity;

	void Awake()
	{
		entity = gameObject.GetComponent<SurfaceEntity>();
	}

	void FixedUpdate()
	{
		entity.body.AddForce(force);
	}
}
