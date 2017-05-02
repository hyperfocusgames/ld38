using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraRig : SingletonBehaviour<CameraRig> {

	public AnimationCurve planetZoomFactor = AnimationCurve.Linear(0, 1, 1, 1);

	Camera _cam;
	public Camera cam {
		get {
			if (_cam == null ) {
				_cam = GetComponentInChildren<Camera>();
			}
			return _cam;
		}
	}
	
	OcclusionCullingTrigger _occlusionCuller;
	public OcclusionCullingTrigger occlusionCuller {
		get {
			if (_occlusionCuller == null) {
				_occlusionCuller = GetComponentInChildren<OcclusionCullingTrigger>();
			}
			return _occlusionCuller;
		}
	}
	public Color skyColor {
		get { return cam.backgroundColor; }
		set { cam.backgroundColor = value; }
	}

	void Update() {
		PlayerData player = PlayerData.player;
		Planet planet = Planet.activePlanet;
		if (player != null) {
			transform.position = planet.transform.position;
			transform.LookAt(transform.position - (player.entity.normal), transform.up);
		}
	}

	public void ZoomToFitPlanet(Planet planet) {
		float zoom = planet.radius * 2 * planetZoomFactor.Evaluate(planet.radius);
		cam.transform.localPosition = new Vector3(0, 0, - zoom);
		occlusionCuller.Refresh();
	} 


}