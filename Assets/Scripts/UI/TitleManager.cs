using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    public GameObject creditsPanel;
    public Button startButton;
    public Button quitButton;
    public Button creditsButton;

    private Animator animator;
    private bool toggle;

	void Start () {
        animator = creditsPanel.GetComponent<Animator>();

        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        creditsButton.onClick.AddListener(Credits);
				// clean up any old player object
				if (PlayerData.player != null) {
					Destroy(PlayerData.player.gameObject);
				}
				MusicManager.instance.menuEffectEnabled = true;
	}

    void StartGame() {
        SceneManager.LoadScene(1);
    }

    void Credits() {
        animator.SetTrigger("toggle");
    }

    void QuitGame() {
        Debug.Log("game quit!");
        Application.Quit();
    }
}
