using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : SingletonBehaviour<LevelManager> {

	public string levelName;
	public PlayerData playerPrefab;
	public PlayerSpawn playerSpawnPrefab;
	public WarpGate warpGatePrefab;
	public EnemySpawn enemySpawnPrefab;
	public int planetCount = 5;
	public WeightedPlanet[] planetPrefabs;
	public EnemySpawnInfo[] enemySpawns;
	public string upgradesScene = "Upgrades";
	public string nextLevel = "";

	public int planetNumber { get; private set; }

	public Planet planet { get; private set; }

	public static string nextLevelAfterUpgrades { get; private set; }

	void Awake() {
		planetNumber = 0;
		if (PlayerData.player == null) {
			Instantiate(playerPrefab);
		}
		NextPlanet();
	}

	public void NextPlanet() {
		PlayerData player = PlayerData.player;
		player.BroadcastMessage("OnPlanetEnd", SendMessageOptions.DontRequireReceiver);
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
			planet.BroadcastMessage("OnPlanetStart", planet, SendMessageOptions.DontRequireReceiver);
			foreach (Projectile projectile in FindObjectsOfType<Projectile>()) {
				Destroy(projectile.gameObject);
			}
			UI.instance.UpdateLevelText();
		}
		else {
			NextLevel();
		}
	}

	public void NextLevel() {
		nextLevelAfterUpgrades = nextLevel;
		SceneManager.LoadScene(upgradesScene);
	}

	[System.Serializable]
	public class WeightedPlanet : WeightedElement<Planet> {}

	[System.Serializable]
	public class EnemySpawnInfo {
		public EnemyData prefab;
		public AnimationCurve spawnRate = AnimationCurve.Linear(0, 1, 1, 1);
		public float spawnFactor = 1;
		public int maxClusterSize = 1;
	}

}
