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
			// transform.forward = - trackTarget.normal;
		}
	}

}
