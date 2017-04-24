using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI3D : SingletonBehaviour<UI3D> {

	public Camera cam { get; private set; }

	void Awake() {
		cam = GetComponent<Camera>();
	}

}
