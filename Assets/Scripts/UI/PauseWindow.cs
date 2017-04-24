using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseWindow : SingletonBehaviour<PauseWindow> {

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
		}
	}

	void Awake() {
		instance.gameObject.SetActive(false);
	}

}
