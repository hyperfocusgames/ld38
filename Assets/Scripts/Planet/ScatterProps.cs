using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScatterProps : GenerationModule {

	public PropScatter[] propScatter;

	public override void Generate() {	
		foreach (PropScatter propScatter in propScatter) {
			propScatter.PlaceClusters(this);
		}
	}

	[System.Serializable]
	public class PropScatter {

		public TerrainProp prefab;
		public AnimationCurve spawnRate = AnimationCurve.Linear(0, 1, 1, 1);
		public int clusterCount = 5;

		public int clusterSize = 10;
		public float clusterRadius = 1;

		public void PlaceClusters(GenerationModule module) {
			int clusterCount = (int) spawnRate.Evaluate(Random.value) * this.clusterCount;
			for (int i = 0; i < clusterCount; i ++) {
				Vector3 clusterCenter = Random.onUnitSphere * module.planet.radius;
				Transform cluster = new GameObject(string.Format("{0} cluster {1}", prefab.name, i)).transform;
				cluster.transform.parent = module.planet.transform;
				cluster.localPosition = Vector3.zero;
				for (int j = 0; j < clusterSize; j ++) {
					TerrainProp prop = Instantiate(prefab);
					prop.name = string.Format("{0} {1}", prefab.name, j);
					Vector3 position = clusterCenter + Random.onUnitSphere * clusterRadius;
					if (module.PlaceProp(prop, position)) {
						prop.transform.parent = cluster;
					}
				}
			}
		}
	}

}
