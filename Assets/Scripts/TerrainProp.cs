using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainProp : MonoBehaviour {

	public float radius;

	public Planet planet { get; private set; }

	public void AttachToPlanet(Planet planet)	{
		this.planet = planet;
		transform.parent = planet.transform;
		transform.localPosition = transform.localPosition.normalized * planet.radius;
	}

	void OnDrawGizmosSelected() {
		Color color = Gizmos.color;
		Gizmos.color = new Color(1, 0.9f, 0.9f);
		Gizmos.DrawWireSphere(transform.position, radius);
		Gizmos.color = color;
	}

}
