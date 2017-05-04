using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MobileSetup : MonoBehaviour {
	
	public string normalMenuSceneName;
	public string mobileMenuSceneName;

	void Awake() {
		if (Application.isMobilePlatform) {
			DontDestroyOnLoad(gameObject);
			SceneManager.LoadScene(mobileMenuSceneName);
		}
		else {
			SceneManager.LoadScene(normalMenuSceneName);
		}
	}

}
