using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planet : MonoBehaviour {

	public Transform surfaceModel;
	public float enemySpawnFactor = 1;
	public Gradient sky;
	public AudioClip customMusic;

	float _radius;
	public float radius {
		get {
			return _radius;
		} set {
			_radius = value;
			if (surfaceModel != null) {
				surfaceModel.transform.localScale = Vector3.one * value * 2;
			}
		}
	}
	public WarpGate warpGate { get; set; }

	static Planet _activePlanet;
	public static Planet activePlanet {
		get {
			LevelManager level = LevelManager.instance;
			if (level != null) {
				return level.planet;
			}
			if (_activePlanet == null) {
				_activePlanet = FindObjectOfType<Planet>();
			}
			return _activePlanet;
		}
	}

	void Start() {
		MusicManager music = MusicManager.instance;
		if (music != null) {
			if (customMusic != null) {
				music.SetCustomMusic(customMusic);
			}
			else {
				music.ResetCustomMusic();
			}
		}
	}

}
