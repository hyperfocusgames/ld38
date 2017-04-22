using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UpgradesScreen : MonoBehaviour
{
	public Button button;

	private Upgrade[] upgrades;

	void Awake ()
	{
		upgrades = new Upgrade[UpgradesDeck.numUpgradesToDraw];
		if(button != null)
		{
			for(int i = 0; i < UpgradesDeck.numUpgradesToDraw; i++)
			{
				Button b = Instantiate(button, Vector3.zero, Quaternion.identity);
				b.transform.SetParent(transform);
				Upgrade u = UpgradesDeck.draw();
				b.GetComponent<UpgradeButton>().Upgrade = u;
			}
		}
	}

	public void restore()
	{

	}
}
