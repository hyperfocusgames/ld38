using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public Button menu;
    public Button quit;

    void Start() {
        menu.onClick.AddListener(ReturnToMenu);
        quit.onClick.AddListener(QuitGame);
    }

    void ReturnToMenu() {
        SceneManager.LoadScene("Title");
    }

    void QuitGame() {
        Debug.Log("game quit!");
        Application.Quit();
    }
}
