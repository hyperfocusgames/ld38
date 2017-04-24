using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAfterX : MonoBehaviour {

	public string scene = "";
	public float seconds = 70;

	// Use this for initialization
	void Start () {
		StartCoroutine(Wait());
	}

	IEnumerator Wait() {
		yield return new WaitForSeconds(seconds);
	}

	protected void loadNextScene()
	{
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
