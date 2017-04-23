using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : SingletonBehaviour<LevelManager> {

	public WarpGate warpGatePrefab;
	public Planet[] planetPrefabs;

	public int minPlanetCount = 4;
	public int maxPlanetCount = 6;

	public int planetCount { get; private set; }
	public int planetNumber { get; private set; }

	public Planet planet { get; private set; }

	void Awake() {
		planetCount = Random.Range(minPlanetCount, maxPlanetCount + 1);
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
		}
		else {
			GameManager.levelFinished();
		}
	}

}
