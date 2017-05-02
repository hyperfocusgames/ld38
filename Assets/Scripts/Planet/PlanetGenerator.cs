using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// main planet generation module responsible for spawning the player, placing
// the exit portal, spawning enemies, and calling all other modules for the
// planet. other modules are called in the order they are placed on the planet GameObject
public class PlanetGenerator : GenerationModule {

	public bool generateOnAwake = true;
	public float averageRadius = 5;				// average planet radius
	public float radiusVariance = 0.5f;		// maximum random variation of planet radius

	public PlayerSpawn playerSpawnPrefab;
	public WarpGate warpGatePrefab;
	public EnemySpawn enemySpawnPrefab;

	public LayerMask propMaskLayers = 0; //	layers to check against when placing props (cannot place props in spaces in these layers) 

	Planet _planet;
	public override Planet planet { get { return _planet; } }
	public List<TerrainProp> props { get; private set; }

	void Awake() {
		_planet = GetComponent<Planet>();
		props = new List<TerrainProp>();
		if (generateOnAwake) {
			Generate();
		}
	}

	public override void Generate() {
		planet.radius = averageRadius + Random.Range(-radiusVariance, radiusVariance);
		System.Func<Vector3> oppositePlayer;
		if (playerSpawnPrefab != null) {
			// place player spawn
			PlayerSpawn playerSpawn = EnsurePropSpawn(playerSpawnPrefab);
			oppositePlayer = () => {
				Vector3 p = Random.onUnitSphere;
				p *= - Vector3.Dot(p, playerSpawn.transform.localPosition);
				return p;
			};
		}
		else {
			oppositePlayer = () => Random.onUnitSphere;
		}
		if (warpGatePrefab != null) {
			// place exit portal
			planet.warpGate = EnsurePropSpawn(warpGatePrefab, oppositePlayer);
		}
		LevelManager level = LevelManager.instance;
		if (level != null) {
			// place enemy spawns
			LevelManager.EnemySpawnInfo[] spawnInfos = level.enemySpawns;
			float progress = (float) level.planetNumber / level.planetCount;
			foreach (LevelManager.EnemySpawnInfo spawnInfo in spawnInfos) {
				int count = (int) Mathf.Ceil(spawnInfo.spawnRate.Evaluate(progress) * spawnInfo.spawnFactor * planet.enemySpawnFactor);
				while (count > 0) {
					int clusterSize = (count > spawnInfo.maxClusterSize) ? spawnInfo.maxClusterSize : count;
					EnemySpawn spawn = EnsurePropSpawn(enemySpawnPrefab, oppositePlayer);
					spawn.prefab = spawnInfo.prefab;
					spawn.enemyCount = clusterSize;
					count -= spawnInfo.maxClusterSize;
				}
			}
		}
		foreach (GenerationModule module in GetComponents<GenerationModule>()) {
			if (module != this) {
				module.Generate();
			}
		}
	}

}
