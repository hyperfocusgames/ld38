using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetGenerator : MonoBehaviour {

	public TerrainProp mountainPrefab;
	public int mountainCount = 20;

	Planet planet;

	void Awake() {
		planet = GetComponent<Planet>();
		ScatterProps(mountainPrefab, mountainCount);
	}

	void ScatterProps(TerrainProp propPrefab, int count) {
		for (int i = 0; i < count; i ++) {
			TerrainProp prop = Instantiate(propPrefab);
			prop.name = propPrefab.name;
			Vector3 position = Random.onUnitSphere;
			PlaceProp(prop, position);
		}
	}

	void PlaceProp(TerrainProp prop, Vector3 position) {
			prop.transform.position = planet.transform.position + position;
			prop.AttachToPlanet(planet);
			Vector3 normal = prop.transform.localPosition.normalized;
			Vector3 forward = Vector3.ProjectOnPlane(Random.onUnitSphere, normal);
			prop.transform.LookAt(prop.transform.position + forward, normal);
	}

}
