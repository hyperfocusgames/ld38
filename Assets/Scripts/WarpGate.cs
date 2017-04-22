using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpGate : MonoBehaviour
{
	void OnTriggerEnter(Collider col)
	{
		Debug.Log("Collision : " + col.gameObject.name);
		if(col.tag == "Player")
		{
			GameManager.levelFinished();
		}
	}
}
