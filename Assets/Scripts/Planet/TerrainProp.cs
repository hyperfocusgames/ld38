using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainProp : MonoBehaviour {

	public float radius;

	public Planet planet { get; set; }

	void OnDrawGizmosSelected() {
		Color color = Gizmos.color;
		Gizmos.color = new Color(1, 0.9f, 0.9f);
		Gizmos.DrawWireSphere(transform.position, radius);
		Gizmos.color = color;
	}

}
