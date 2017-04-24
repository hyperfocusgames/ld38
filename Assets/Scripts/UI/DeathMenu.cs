﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : SingletonBehaviour<DeathMenu> {

	public float fadeInTime = 2;

	public Button menu;
	public Button quit;

	CanvasGroup group;

	void Awake() {
		instance.gameObject.SetActive(false);
		group = GetComponent<CanvasGroup>();
	}

	public void ReturnToMenu() {
		SceneManager.LoadScene("Title");
	}

	public void QuitGame() {
		Debug.Log("game quit!");
		Application.Quit();
	}

	public void Show() {
		gameObject.SetActive(true);
		StartCoroutine(ShowRoutine());
	}
	
	void Update() {
		MusicManager.instance.menuEffectEnabled = true;
	}

	IEnumerator ShowRoutine() {
		float t = 0;
		while (t < fadeInTime) {
			group.alpha = t / fadeInTime;
			t += Time.deltaTime;
			yield return null;
		}
		group.alpha = 1;
	}
}
