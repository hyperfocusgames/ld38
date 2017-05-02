using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainProp : MonoBehaviour {

	public float exclusionRadius; // radius within which existing props cannot be placed
	public float boundingRadius; // bounding radius for occlusion culling

	public Planet planet { get; set; }

	Renderer[] _renderers;
	Renderer[] renderers {
		get {
			if (_renderers == null) {
				_renderers = GetComponentsInChildren<Renderer>();
			}
			return _renderers;
		}
	}

	public bool visible {
		set {
			foreach (Renderer renderer in renderers) {
				renderer.enabled = value;
			}
		}
	}

	void OnDrawGizmosSelected() {
		Color color = Gizmos.color;
		Gizmos.color = new Color(1, 0.9f, 0.9f);
		Gizmos.DrawWireSphere(transform.position, exclusionRadius);
		Gizmos.color = color;
	}

}
