using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : Singleton<SpawnSystem>
{

	public float spawnDelay;
	int ballsCounter = 0;



    public void StartSpawning()
    {
			spawnDelay = 3;
		

		if (actualPlayer != null)
		{
			Destroy(actualPlayer);
		}
		actualPlayer = Instantiate(playersPrefabs[Random.Range(0, playersPrefabs.Length)]);
		genCounter = -2;
		StopAllCoroutines();
		StartCoroutine(Spawn());
    }

	IEnumerator Spawn()
    {
		
		while (true)
        {
			yield return new WaitForSeconds(spawnDelay);
			GenBall();
			GenPlayer();
			//GenPlayerInferno();
			ballsCounter++;

			if (ballsCounter > 6)
			{
				ballsCounter = 0;
				if (spawnDelay > 0.8f)
				{
					spawnDelay -= 0.2f;
				}

			}
		}
    }

	public void EndSpawning()
    {
		StopAllCoroutines();
		
		//this will clear the stage from all the remaining balls.
		foreach (GameObject ball in inGameBalls)
        {
			if(ball != null)
			Destroy(ball);
        }
		inGameBalls.Clear();
		
	}

	#region PLAYER REGION
	[SerializeField] GameObject[] playersPrefabs;
	GameObject actualPlayer;

	public int genCounter;
	public void GenPlayer()
	{
        
			int x = Random.Range(0, genCounter);
            if (x > 0)
            {
				if (actualPlayer != null)
				{
					Destroy(actualPlayer);
				}
				actualPlayer = Instantiate(playersPrefabs[Random.Range(0, playersPrefabs.Length)]);
				genCounter = -2;
			}
			else
			{
				genCounter++;
			}
	}

	public void GenPlayerInferno()
	{
			if (actualPlayer != null)
			{
				Destroy(actualPlayer);
			}
			actualPlayer = Instantiate(playersPrefabs[Random.Range(0, playersPrefabs.Length)]);
	}
	#endregion


	#region BALL REGION
	[SerializeField] GameObject[] _ballsPrefabs;
	List<GameObject> inGameBalls = new List<GameObject>();

	//This pseudo-randomic method generates a random ball picked from the 3 possible types
	public void GenBall()
	{
		int percentage = Random.Range(0, 100);
		if (percentage > 94)
		{
			//Dark Ball
			inGameBalls.Add(Instantiate(_ballsPrefabs[2]));
		}
		else if (percentage > 90 && percentage < 95)
		{
			//Golden Ball
			inGameBalls.Add(Instantiate(_ballsPrefabs[1]));
		}
		else if (percentage < 91)
		{
			//Normal Ball
			inGameBalls.Add(Instantiate(_ballsPrefabs[0]));
		}
	}
    #endregion
}
