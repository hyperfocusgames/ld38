using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomMesh : MonoBehaviour {

	public WeightedMesh[] meshes;

	void Awake() {
		MeshFilter filter = GetComponent<MeshFilter>();
		filter.mesh = meshes.WeightedChoice();
	}

	[System.Serializable]
	public class WeightedMesh : WeightedElement<Mesh> {}

}
