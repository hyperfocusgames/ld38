using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
	private static int numEnemies = 0;

    public static int NumEnemies
	{
		get{ return numEnemies; }
	}

    private static void findEnemies()
	{
		numEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
	}

	public static void killEnemy()
	{
		numEnemies--;
		if(NumEnemies <= 0)
		{
			// Finished
		}
	}

	public static void spawnEnemy()
	{
		numEnemies++;
	}

	public static void levelFinished()
	{
		
	}
}
