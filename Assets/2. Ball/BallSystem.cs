using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSystem : Singleton<BallSystem>
{
	[SerializeField] GameObject ballPrefab;
	[SerializeField] GameObject goldenBallPrefab;
	[SerializeField] GameObject darkBallPrefab;

	[SerializeField] float startingTime;
	[SerializeField] float delayTime;

	GameObject lastBall;
	public void GoBalls()
    {
		InvokeRepeating("GenBall", startingTime, delayTime);
		timer = 0;

	}

	float timer;

	private void Update()
    {
		timer += Time.deltaTime;
		if(timer > 60)
        {
			delayTime -= 0.5f;
			timer = 0;
		}

	}

    public void GenBall()
	{
		int percentage = Random.Range(0, 100);

		if (percentage > 94 && goldenBallPrefab != null)
		{
			lastBall = Instantiate(goldenBallPrefab);
		}
		else if (percentage > 90 && percentage < 95 && darkBallPrefab != null)
        {
			lastBall = Instantiate(darkBallPrefab);
		}
        else if(percentage < 91)
        {
			lastBall = Instantiate(ballPrefab);
		}
	}

	public void StopBallsGeneration()
    {
		Destroy(lastBall);
		CancelInvoke();
		timer = 0;
	}
}
