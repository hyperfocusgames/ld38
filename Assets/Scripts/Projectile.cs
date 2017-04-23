﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	private const float timeout = 1f;
	private float startTime;
	public float speed;
	SurfaceEntity entity;

	void Awake()
	{
		entity = GetComponent<SurfaceEntity>();
		startTime = Time.time;
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
