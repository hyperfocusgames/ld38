using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAlignment : MonoBehaviour {

	public Vector3 offset = new Vector3(0.1f, 0.9f, 5);
	private Camera uiCam;

	void Start() {
		uiCam = GameObject.FindGameObjectWithTag("UI Camera").GetComponent<Camera>();
	}

	void Update () {
		Vector3 worldPoint = uiCam.ViewportToWorldPoint(offset);
		transform.position = worldPoint;
	}

}
