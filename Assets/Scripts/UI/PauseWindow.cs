using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseWindow : SingletonBehaviour<PauseWindow> {

	Stats stats;

	bool _isPaused;
	public bool isPaused {
		get {
			return _isPaused;
		}
		set {
			_isPaused = value;
			gameObject.SetActive(value);
			Time.timeScale = value ? 0 : 1;
			MusicManager.instance.menuEffectEnabled = value;
			if (value) {
				stats.UpdateStats();
			}
		}
	}

	void Update() {
		MusicManager.instance.menuEffectEnabled = isPaused;
	}

	void Awake() {
		stats = GetComponentInChildren<Stats>();
		instance.gameObject.SetActive(false);
	}

}
