using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    private Upgrade _upgrade;

    public Upgrade upgrade
	{
		get{ return _upgrade; }
		set
		{
			gameObject.GetComponentInChildren<Text>().text = value.toString();
			_upgrade = value;
		}
	}

    public void activate()
	{
		upgrade.activate();
		UpgradesScreen.instance.Finish();
	}
}
