using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UI : SingletonBehaviour<UI> {

	PauseWindow pauseWindowPrefab;

	public Text levelText;

	public void ShowDeathScreen() {
		DeathMenu.instance.Show();
	}

	void Update() {
		if (Input.GetButtonDown("Pause")) {
			PauseWindow pause = PauseWindow.instance;
			pause.isPaused = !pause.isPaused;
		}
	}

	public void UpdateLevelText() {
		LevelManager level = LevelManager.instance;
		levelText.text = string.Format("{0}-{1}/{2}", level.levelName, level.planetNumber, level.planetCount);
	}

}
