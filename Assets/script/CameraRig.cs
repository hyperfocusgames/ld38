using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraRig : SingletonBehaviour<CameraRig> {

	public Camera cam { get; private set; }

	void Awake() {
		cam = GetComponent<Camera>();
	}

}
