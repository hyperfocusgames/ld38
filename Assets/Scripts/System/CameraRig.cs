using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraRig : SingletonBehaviour<CameraRig> {

	public Camera cam { get; private set; }
	public AnimationCurve planetZoomFactor = AnimationCurve.Linear(0, 1, 1, 1);
    public GameObject occlusionCullerPrefab;
    private GameObject occlusionCuller;

    public Color skyColor {
		get { return cam.backgroundColor; }
		set { cam.backgroundColor = value; }
	}

	void Awake() {
		cam = GetComponentInChildren<Camera>();
        occlusionCuller = Instantiate(occlusionCullerPrefab, transform);
	}

	void Update() {
		PlayerData player = PlayerData.player;
		Planet planet = LevelManager.instance.planet;
        if (player != null) {
			transform.position = planet.transform.position;
			transform.LookAt(transform.position - player.transform.localPosition, transform.up);
		}
	}

	public void ZoomToFitPlanet(Planet planet) {
		transform.localScale = new Vector3(
			1,
			1,
			planet.radius * 2 * planetZoomFactor.Evaluate(planet.radius)
		);
        occlusionCuller.transform.localPosition = new Vector3(0, 0, 5.1f);
        occlusionCuller.GetComponent<OcclusionCullingTrigger>().Refresh();
    }


}
