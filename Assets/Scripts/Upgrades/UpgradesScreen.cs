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

	void Awake ()
	{
		group = GetComponent<CanvasGroup>();
		upgrades = new Upgrade[UpgradesDeck.numUpgradesToDraw];
		eventSystem = GameObject.Find ("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem> ();
		if(button != null)
		{
			for(int i = 0; i < UpgradesDeck.numUpgradesToDraw; i++)
			{
				Button b = Instantiate(button, Vector3.zero, Quaternion.identity);
				if(i == 0) eventSystem.SetSelectedGameObject(b.gameObject);
				b.transform.SetParent(transform);
				Upgrade u = UpgradesDeck.draw();
				b.GetComponent<UpgradeButton>().upgrade = u;
			}
		}
		MusicManager.instance.menuEffectEnabled = true;
	}

	public void Finish() {
		SceneManager.LoadScene(LevelManager.nextLevelAfterUpgrades);
		group.interactable = false;
		MusicManager.instance.menuEffectEnabled = false;
	}

}
