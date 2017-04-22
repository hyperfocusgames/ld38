using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
	public int hp = 1;

	public void set(int val)
	{
		hp = val;
	}

	public void damage(int dam)
	{
		hp -= dam;
		if(hp <= 0)
		{
			Destroy(gameObject);
		}
	}
}
