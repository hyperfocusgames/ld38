using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraRig : SingletonBehaviour<CameraRig> {

	public SurfaceEntity trackTarget;
	public Camera cam { get; private set; }
	public AnimationCurve planetZoomFactor = AnimationCurve.Linear(0, 1, 1, 1);

	void Awake() {
		cam = GetComponentInChildren<Camera>();
	}

	void Update() {
		if (trackTarget != null) {
			transform.position = trackTarget.planet.transform.position;
			transform.LookAt(transform.position - trackTarget.transform.localPosition, transform.up);
		}
	}

	public void ZoomToFitPlanet(Planet planet) {
		transform.localScale = new Vector3(
			1,
			1,
			planet.radius * 2 * planetZoomFactor.Evaluate(planet.radius)
		);
	} 

}
