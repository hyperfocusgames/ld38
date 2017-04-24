using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumEnemies : MonoBehaviour
{
	private string str = "Enemies Remaining\n";

	private Text text;
	void Awake ()
	{
		text = GetComponent<Text>();
		text.text = str + EnemyData.livingCount;
	}
}
