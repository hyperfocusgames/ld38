using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : SingletonBehaviour<LevelManager> {

	public WarpGate warpGatePrefab;
	public PlayerSpawn playerSpawnPrefab;
	public Planet[] planetPrefabs;

	public int planetCount = 5;
	public int planetNumber { get; private set; }

	public Planet planet { get; private set; }

	void Awake() {
		planetNumber = 0;
		NextPlanet();
	}

	public void NextPlanet() {
		if (planetNumber < planetCount) {
			planetNumber ++;
			if (planet != null) {
				Destroy(planet.gameObject);
			}
			Planet prefab = planetPrefabs[Random.Range(0, planetPrefabs.Length)];
			planet = Instantiate(prefab);
			planet.name = prefab.name;
			foreach (SurfaceEntity entity in FindObjectsOfType<SurfaceEntity>()) {
				entity.planet = planet;
			}
			CameraRig rig = CameraRig.instance;
			rig.cam.backgroundColor = planet.backgroundColor;
			rig.ZoomToFitPlanet(planet);

		}
		else {
			GameManager.levelFinished();
		}
	}

}
