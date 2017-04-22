using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    private Upgrade upgrade;

    public Upgrade Upgrade
	{
		get{ return upgrade; }
		set
		{
			gameObject.GetComponentInChildren<Text>().text = value.toString();
			upgrade = value;
		}
	}

    public void activate()
	{
		Upgrade.activate();
		gameObject.GetComponentInParent<UpgradesScreen>();
		GameManager.upgradesFinished();
		Destroy(gameObject);
	}
}
