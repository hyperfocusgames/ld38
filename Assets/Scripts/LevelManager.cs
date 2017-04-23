using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : SingletonBehaviour<LevelManager> {

	public WarpGate warpGatePrefab;
	public PlayerSpawn playerSpawnPrefab;
	public WeightedPlanet[] planetPrefabs;

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
			Planet prefab = planetPrefabs.WeightedChoice();
			planet = Instantiate(prefab);
			planet.name = prefab.name;
			foreach (SurfaceEntity entity in FindObjectsOfType<SurfaceEntity>()) {
				entity.planet = planet;
			}
			CameraRig rig = CameraRig.instance;
			rig.ZoomToFitPlanet(planet);
		}
		else {
			GameManager.levelFinished();
		}
	}

	[System.Serializable]
	public class WeightedPlanet : WeightedElement<Planet> {}

}
