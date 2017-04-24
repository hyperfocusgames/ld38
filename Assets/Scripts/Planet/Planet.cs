using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planet : MonoBehaviour {

	public Transform surfaceModel;
	public float radius = 1;
	public float enemySpawnFactor = 1;
	public float radiusVariance = 0.5f;
	public Gradient sky;
	public AudioClip customMusic;

	public WarpGate warpGate { get; set; }

	void Awake() {
		radius += Random.Range(-radiusVariance, radiusVariance);
		surfaceModel.localScale = Vector3.one * radius * 2;
	}

	void Start() {
		if (customMusic != null) {
			MusicManager.instance.SetCustomMusic(customMusic);
		}
		else {
			MusicManager.instance.ResetCustomMusic();
		}
	}

	void OnValidate() {
		if (surfaceModel) {
			surfaceModel.localScale = Vector3.one * radius * 2;
		}
	}

	void Update() {
		CameraRig rig = CameraRig.instance;
		Sun sun = Sun.instance;
		float day = Vector3.Dot(rig.transform.forward.normalized, sun.transform.forward.normalized);
		day = (day + 1) / 2;
		rig.skyColor = sky.Evaluate(day);
	}

}
