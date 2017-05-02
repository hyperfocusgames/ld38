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

	void LateUpdate() {
		Planet planet = Planet.activePlanet;
		Vector3 forward = transform.forward;
		foreach (TerrainProp prop in planet.generator.props) {
			Vector3 propPos = Vector3.ProjectOnPlane(prop.transform.position, forward);
			Vector3 planetPos = Vector3.ProjectOnPlane(planet.transform.position, forward);
			if (Vector3.Distance(cam.transform.position, prop.transform.position) >
			    Vector3.Distance(cam.transform.position, planet.transform.position)) {
				Vector3 diff = propPos - planetPos;
				prop.visible = !(diff.magnitude < (planet.radius - prop.boundingRadius));
			}
			else {
				prop.visible = true;
			}
		}
	}

	public void ZoomToFitPlanet(Planet planet) {
		float zoom = planet.radius * 2 * planetZoomFactor.Evaluate(planet.radius);
		cam.transform.localPosition = new Vector3(0, 0, - zoom);
		// occlusionCuller.Refresh();
	} 


}