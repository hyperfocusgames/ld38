using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : TerrainProp {

	public int enemyCount;
	public EnemyData prefab;

	void OnPlanetStart(Planet planet) {
		for (int i = 0; i < enemyCount; i ++) {
			EnemyData enemy = Instantiate(prefab);
			enemy.name = prefab.name;
			enemy.transform.position = transform.position;
			enemy.transform.SetParent(planet.transform, true);
		}
	}

}
