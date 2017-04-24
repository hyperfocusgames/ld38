using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CompoundEffect : MonoBehaviour {

	public WeightedPrefab[] effectPrefabs;
	public float minSpawnTime = 0.05f;
	public float maxSpawnTime = 0.075f;
	public float radius = 0.5f;
	public float duration = 1;

	void Start() {
		StartCoroutine(EffectRoutine());
	}

	IEnumerator EffectRoutine() {
		float t = 0;
		while (t < duration) {
			Transform prefab = effectPrefabs.WeightedChoice();
			Transform effect = Instantiate(prefab);
			effect.transform.position = transform.position + Random.insideUnitSphere * radius;
			float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
			t += spawnTime;
			yield return new WaitForSeconds(spawnTime);
		}
		Destroy(gameObject);
	}

	[System.Serializable]
	public class WeightedPrefab : WeightedElement<Transform> {}

}
