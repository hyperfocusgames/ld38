using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraRig : SingletonBehaviour<CameraRig> {

	public Camera cam { get; private set; }
	public AnimationCurve planetZoomFactor = AnimationCurve.Linear(0, 1, 1, 1);

	public Color skyColor {
		get { return cam.backgroundColor; }
		set { cam.backgroundColor = value; }
	}

	void Awake() {
		cam = GetComponentInChildren<Camera>();
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
		transform.localScale = new Vector3(
			1,
			1,
			planet.radius * 2 * planetZoomFactor.Evaluate(planet.radius)
		);
	} 


}
