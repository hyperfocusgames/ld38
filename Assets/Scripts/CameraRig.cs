using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraRig : SingletonBehaviour<CameraRig> {

	public SurfaceEntity trackTarget;
	public Camera cam { get; private set; }

	void Awake() {
		cam = GetComponent<Camera>();
	}

	void Update() {
		if (trackTarget != null) {
			transform.position = trackTarget.planet.transform.position;
			transform.LookAt(-trackTarget.transform.up, trackTarget.body.velocity);
		}
	}

}
