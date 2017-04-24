using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class UpgradesScreen : SingletonBehaviour<UpgradesScreen>
{
	public Button button;

	private Upgrade[] upgrades;
	private UnityEngine.EventSystems.EventSystem eventSystem;

	CanvasGroup group;

	void Awake () {
		if (!UpgradesDeck.isInitialized) {
			UpgradesDeck.InitializeDeck();
		}
		group = GetComponent<CanvasGroup>();
		upgrades = UpgradesDeck.draw();
		eventSystem = GameObject.Find ("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem> ();
		if(button != null) {
			for(int i = 0; i < upgrades.Length; i++) {
				Button b = Instantiate(button, Vector3.zero, Quaternion.identity);
				if(i == 0) eventSystem.SetSelectedGameObject(b.gameObject);
				b.transform.SetParent(transform);
				b.GetComponent<UpgradeButton>().upgrade = upgrades[i];
			}
		}
	}
	
	void Start() {
		MusicManager.instance.menuEffectEnabled = true;
	}

	public void Finish(Upgrade upgrade) {
		foreach (Upgrade u in upgrades) {
			if (u != upgrade && u.limited) {
				UpgradesDeck.AddToDeck(u);
			}
		}
		SceneManager.LoadScene(LevelManager.nextLevelAfterUpgrades);
		group.interactable = false;
		MusicManager.instance.menuEffectEnabled = false;
	}

}
