using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetGenerator : MonoBehaviour {

	public bool generateOnAwake = true;
	public float averageRadius = 5;
	public float radiusVariance = 0.5f;
	public PlayerSpawn playerSpawnPrefab;
	public WarpGate warpGatePrefab;
	public EnemySpawn enemySpawnPrefab;
	public PropScatter[] propScatter;
	public LayerMask propMaskLayers = 0; //	layers to check against when placing props (cannot place props in spaces in these layers) 

	Planet planet;
	List<TerrainProp> props;
	Transform generationRoot;

	void Awake() {
		if (generateOnAwake) {
			Generate();
		}
	}

	[ContextMenu("Generate")]
	void Generate() {
		planet = GetComponent<Planet>();
		if (generationRoot != null) {
			Destroy(generationRoot.gameObject);
		}
		generationRoot = new GameObject("generation").transform;
		generationRoot.parent = planet.transform;
		generationRoot.localPosition = Vector3.zero;
		planet.radius = averageRadius + Random.Range(-radiusVariance, radiusVariance);
		props = new List<TerrainProp>();
		System.Func<Vector3> oppositePlayer;
		if (playerSpawnPrefab != null) {
			PlayerSpawn playerSpawn = EnsurePropSpawn(playerSpawnPrefab);
			oppositePlayer = RandomOpposite(playerSpawn.transform.localPosition);
		}
		else {
			oppositePlayer = () => Random.onUnitSphere;
		}
		if (warpGatePrefab != null) {
			planet.warpGate = EnsurePropSpawn(warpGatePrefab, oppositePlayer);
		}
		LevelManager level = LevelManager.instance;
		if (level != null) {
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
			position = position.normalized * planet.radius;
			if (Physics.CheckSphere(planet.transform.position + position, prop.radius, propMaskLayers)) {
				Destroy(prop.gameObject);
				return false;
			}
			prop.transform.parent = generationRoot;
			prop.transform.localPosition = position;
			prop.planet = planet;
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
				cluster.parent = generator.generationRoot;
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
