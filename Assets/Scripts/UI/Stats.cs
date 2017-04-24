using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
	private const int numStats = 7;
	private enum stats{ speed = 0, hp, shield, shieldRecharge, rof, dam, stun };
	public GameObject panel;
	List<GameObject> statsBoxes = new List<GameObject>(numStats);

	void Awake()
	{
		setup();
	}

	protected void setup()
	{
		for(int i = 0; i < numStats; i++)
		{
			GameObject go = Instantiate(panel, Vector3.zero, Quaternion.identity);
			go.transform.SetParent(transform);
			statsBoxes.Add(go);

			if(i == (int)stats.speed)
			{
				Text[] texts = go.GetComponentsInChildren<Text>();
				foreach(Text t in texts)
				{
					if(t.tag == "StatPanel")
					{
						t.text = "Speed:";
					}
					else
					{
						t.text = PlayerData.NumMoveSpeedUpgrades.ToString();
					}
				}
			}
			else if(i == (int)stats.hp)
			{
				Text[] texts = go.GetComponentsInChildren<Text>();
				foreach(Text t in texts)
				{
					if(t.tag == "StatPanel")
					{
						t.text = "HP:";
					}
					else
					{
						t.text = PlayerData.NumHPUpgrades.ToString();
					}
				}
			}
			else if(i == (int)stats.shield)
			{
				Text[] texts = go.GetComponentsInChildren<Text>();
				foreach(Text t in texts)
				{
					if(t.tag == "StatPanel")
					{
						t.text = "Shield:";
					}
					else
					{
						t.text = PlayerData.NumShieldUpgrades.ToString();
					}
				}
			}
			else if(i == (int)stats.shieldRecharge)
			{
				Text[] texts = go.GetComponentsInChildren<Text>();
				foreach(Text t in texts)
				{
					if(t.tag == "StatPanel")
					{
						t.text = "Shield Recharge:";
					}
					else
					{
						t.text = PlayerData.NumShieldRechargeUpgrades.ToString();
					}
				}
			}
			else if(i == (int)stats.rof)
			{
				Text[] texts = go.GetComponentsInChildren<Text>();
				foreach(Text t in texts)
				{
					if(t.tag == "StatPanel")
					{
						t.text = "Rate of Fire:";
					}
					else
					{
						t.text = PlayerData.NumROFUpgrades.ToString();
					}
				}
			}
			else if(i == (int)stats.dam)
			{
				Text[] texts = go.GetComponentsInChildren<Text>();
				foreach(Text t in texts)
				{
					if(t.tag == "StatPanel")
					{
						t.text = "Damage:";
					}
					else
					{
						t.text = PlayerData.NumDamUpgrades.ToString();
					}
				}
			}
			else if(i == (int)stats.stun)
			{
				Text[] texts = go.GetComponentsInChildren<Text>();
				foreach(Text t in texts)
				{
					if(t.tag == "StatPanel")
					{
						t.text = "Stun:";
					}
					else
					{
						t.text = PlayerData.NumStunUpgrades.ToString();
					}
				}
			}
		}
	}
}
