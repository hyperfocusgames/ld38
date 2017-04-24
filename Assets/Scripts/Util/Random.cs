using UnityEngine;

public class WeightedElement<T> {

	public float weight = 1;
	public T value;

}

public static class WeightedRandom {

	public static T WeightedChoice<T>(this WeightedElement<T>[] list) {
		float total = 0;
		foreach (WeightedElement<T> e in list) {
			if (e.weight == 0) {
				e.weight = 1;
			}
			total += e.weight;
		}
		float choice = Random.value * total;
		foreach (WeightedElement<T> e in list) {
			choice -= e.weight;
			if (choice <= 0) {
				return e.value;
			}
		}
		return list[list.Length - 1].value;
	}

}