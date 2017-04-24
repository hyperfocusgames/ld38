using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{

	public Text titleText;
	public Text descriptionText;


    private Upgrade _upgrade;

    public Upgrade upgrade
	{
		get{ return _upgrade; }
		set
		{
			titleText.text = value.title;
			descriptionText.text = value.description;
			_upgrade = value;
		}
	}

    public void activate()
	{
		upgrade.activate();
		UpgradesScreen.instance.Finish(upgrade);
	}
}
