using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomMesh : MonoBehaviour {

	public Mesh[] meshes;

	void Awake() {
		MeshFilter filter = GetComponent<MeshFilter>();
		filter.mesh = meshes[Random.Range(0, meshes.Length)];
	}

}
