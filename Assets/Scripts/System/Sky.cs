using UnityEngine;

public class Sky : SingletonBehaviour<Sky> {

	public Light sun;

	void Update() {
		Camera camera = Camera.main;
		Planet planet = Planet.activePlanet;
		if (planet != null && camera != null) {
			float day = Vector3.Dot(camera.transform.forward.normalized, sun.transform.forward.normalized);
			day = (day + 1) / 2;
			camera.backgroundColor = planet.sky.Evaluate(day);
		}
	}

}