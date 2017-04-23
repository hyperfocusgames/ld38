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
		foreach (PropScatter propScatter in propScatter) {
			propScatter.PlaceClusters(this);
		}
	}

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
		public int clusterCount = 5;
		public int clusterSize = 10;
		public float clusterRadius = 1;

		public void PlaceClusters(PlanetGenerator generator) {
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
