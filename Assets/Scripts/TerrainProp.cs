using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainProp : MonoBehaviour {

	Planet planet;

	public void AttachToPlanet(Planet planet)	{
		this.planet = planet;
		transform.parent = planet.transform;
		transform.localPosition = transform.localPosition.normalized * planet.radius;
	}

}
