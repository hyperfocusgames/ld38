using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
	private const int numStats = 7;
	private enum stats{ speed = 0, hp, shield, shieldRecharge, rof, dam, stun };
	public GameObject panel;
	GameObject[] statsBoxes = new GameObject[numStats];

	void Awake() {
		Setup();
	}

	public void UpdateStats() {
		for(int i = 0; i < numStats; i++) {
			Text[] texts = statsBoxes[i].GetComponentsInChildren<Text>();
			foreach(Text t in texts) {
				if (!t.CompareTag("StatPanel")) {
					switch ((stats) i) {
						case stats.speed:
							t.text = PlayerData.NumMoveSpeedUpgrades.ToString();
							break;
						case stats.hp:
							t.text = PlayerData.NumHPUpgrades.ToString();
							break;
						case stats.shield:
							t.text = PlayerData.NumShieldUpgrades.ToString();
							break;
						case stats.shieldRecharge:
							t.text = PlayerData.NumShieldRechargeUpgrades.ToString();
							break;
						case stats.rof:
							t.text = PlayerData.NumROFUpgrades.ToString();
							break;
						case stats.dam:
							t.text = PlayerData.NumDamUpgrades.ToString();
							break;
						case stats.stun:
							t.text = PlayerData.NumStunUpgrades.ToString();
							break;
					}
				}
			}
		}
	}

	void Setup() {
		for(int i = 0; i < numStats; i++) {
			GameObject go = Instantiate(panel, Vector3.zero, Quaternion.identity);
			go.transform.SetParent(transform);
			statsBoxes[i] = go;
			Text[] texts = go.GetComponentsInChildren<Text>();
			foreach(Text t in texts) {
				if (t.CompareTag("StatPanel")) {
					switch ((stats) i) {
						case stats.speed:
							t.text = "Speed:";
							break;
						case stats.hp:
							t.text = "HP:";
							break;
						case stats.shield:
							t.text = "Shields:";
							break;
						case stats.shieldRecharge:
							t.text = "Shield Recharge:";
							break;
						case stats.rof:
							t.text = "Rate of Fire:";
							break;
						case stats.dam:
							t.text = "Damage:";
							break;
						case stats.stun:
							t.text = "Stun:";
							break;
					}
				}
			}
		}
	}
}
