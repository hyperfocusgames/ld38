using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float timeout = 2f;
	private float startTime;
	public float speed;
	SurfaceEntity entity;

	void Awake()
	{
		entity = GetComponent<SurfaceEntity>();
		startTime = Time.time;
	}

	// distance along its path from 0 to 1
	public float distance {
		get {
			return (Time.time - startTime) / timeout;
		}
	}

	void FixedUpdate()
	{
		if(Time.time - startTime > timeout)
		{
			Destroy(gameObject);
		}

		entity.body.velocity = transform.forward * speed;
	}

}
