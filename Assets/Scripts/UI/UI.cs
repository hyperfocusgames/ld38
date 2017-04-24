using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI : SingletonBehaviour<UI> {

	public void ShowDeathScreen() {
		DeathMenu.instance.Show();
	}

	void Update() {
		if (Input.GetButtonDown("Pause")) {
			PauseWindow pause = PauseWindow.instance;
			pause.isPaused = !pause.isPaused;
		}
	}

}
