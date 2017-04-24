using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroText : SingletonBehaviour<IntroText> {

	public AudioClip music;

	public string scene = "";
	public float seconds = 70;

	void Start () {
		StartCoroutine(Wait());
		MusicManager.instance.SetCustomMusic(music);
		MusicManager.instance.menuEffectEnabled = false;
	}

	IEnumerator Wait() {
		yield return new WaitForSeconds(seconds);
		loadNextScene();
	}

	protected void loadNextScene()
	{
		MusicManager.instance.ResetCustomMusic();
		SceneManager.LoadScene(scene);
	}

	void Update()
	{
		if(Input.GetButtonDown("Cancel"))
		{
			loadNextScene();
		}
	}
}
