using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetGenerator : MonoBehaviour {

	public PropScatter[] propScatter;

	Planet planet;
	List<TerrainProp> props;

	void Awake() {
		planet = GetComponent<Planet>();
		props = new List<TerrainProp>();
		LevelManager level = LevelManager.instance;
		if (level != null) {
			PlayerSpawn playerSpawn = EnsurePropSpawn(level.playerSpawnPrefab);
			System.Func<Vector3> oppositePlayer = RandomOpposite(playerSpawn.transform.localPosition);
			planet.warpGate = EnsurePropSpawn(level.warpGatePrefab, oppositePlayer);
			LevelManager.EnemySpawnInfo[] spawnInfos = level.enemySpawns;
			float progress = (float) level.planetNumber / level.planetCount;
			foreach (LevelManager.EnemySpawnInfo spawnInfo in spawnInfos) {
				int count = (int) Mathf.Ceil(spawnInfo.spawnRate.Evaluate(progress) * spawnInfo.spawnFactor * planet.enemySpawnFactor);
				// Debug.LogFormat("Planet {0}: Spawned {1} of {2}", level.planetNumber, count, spawnInfo.prefab.name);
				while (count > 0) {
					int clusterSize = (count > spawnInfo.maxClusterSize) ? spawnInfo.maxClusterSize : count;
					EnemySpawn spawn = EnsurePropSpawn(level.enemySpawnPrefab, oppositePlayer);
					spawn.prefab = spawnInfo.prefab;
					spawn.enemyCount = clusterSize;
					count -= spawnInfo.maxClusterSize;
				}
			}
		}
		foreach (PropScatter propScatter in propScatter) {
			propScatter.PlaceClusters(this);
		}
	}

	// return a random position on the opposite hemisphere from a given point
	System.Func<Vector3> RandomOpposite(Vector3 position) {
		return () => {
			Vector3 p = Random.onUnitSphere;
			p *= - Vector3.Dot(p, position);
			return p;
		};
	}

	// try to spawn and place a prop, make sure it happens
	T EnsurePropSpawn<T>(T prefab, System.Func<Vector3> position) where T : TerrainProp {
			T prop;
			do {
				prop = Instantiate(prefab);
				prop.name = prefab.name;
			} while(!PlaceProp(prop, position()));
			return prop;
	}
	T EnsurePropSpawn<T>(T prefab) where T : TerrainProp { return EnsurePropSpawn(prefab, () => Random.onUnitSphere); }

	// try to place a prop at a position on the planet (position in planetary local space)
	// if there is not enough space, destroy the prop and return false
	// return true if prop is succesfully placed
	bool PlaceProp(TerrainProp prop, Vector3 position) {
			prop.transform.position = planet.transform.position + position;
			prop.AttachToPlanet(planet);
			foreach (TerrainProp p in props) {
				float distance = Vector3.Distance(p.transform.position, prop.transform.position);
				if (distance < (p.radius + prop.radius)) {
					Destroy(prop.gameObject);
					return false;
				}
			}
			props.Add(prop);
			// randomize facing direction
			Vector3 normal = prop.transform.localPosition.normalized;
			Vector3 forward = Vector3.ProjectOnPlane(Random.onUnitSphere, normal);
			prop.transform.LookAt(prop.transform.position + forward, normal);
			return true;
	}

	[System.Serializable]
	public class PropScatter {

		public TerrainProp prefab;
		public AnimationCurve spawnRate = AnimationCurve.Linear(0, 1, 1, 1);
		public int clusterCount = 5;

		public int clusterSize = 10;
		public float clusterRadius = 1;

		public void PlaceClusters(PlanetGenerator generator) {
			int clusterCount = (int) spawnRate.Evaluate(Random.value) * this.clusterCount;
			for (int i = 0; i < clusterCount; i ++) {
				Vector3 clusterCenter = Random.onUnitSphere * generator.planet.radius;
				Transform cluster = new GameObject(string.Format("{0} cluster {1}", prefab.name, i)).transform;
				cluster.parent = generator.planet.transform;
				cluster.localPosition = Vector3.zero;
				for (int j = 0; j < clusterSize; j ++) {
					TerrainProp prop = Instantiate(prefab);
					prop.name = string.Format("{0} {1}", prefab.name, j);
					Vector3 position = clusterCenter + Random.onUnitSphere * clusterRadius;
					if (generator.PlaceProp(prop, position)) {
						prop.transform.parent = cluster;
					}
				}
			}
		}
	}

}
