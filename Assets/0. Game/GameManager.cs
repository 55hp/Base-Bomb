using UnityEngine;

public class GameManager : Singleton<GameManager>
{

	int points;
	public void AddPoints(int amount)
    {
		points += amount;
		UIManager.Instance.RefreshPointsText(points);
	}

	public void SubPoints(int amount)
    {
		points -= amount;

        if (points < 0)
        {
			points = 0;
		}
		UIManager.Instance.RefreshPointsText(points);
	}

	public void ResetPoints()
	{
		points = 0;
		UIManager.Instance.RefreshPointsText(points);
	}

	public void StartGame()
    {
		UIManager.Instance.DisableStartScreen();
		Time.timeScale = 1;
		points = 0;
		SpawnSystem.Instance.StartSpawning();
	}

	public void PauseGame()
    {
		Time.timeScale = 0;
		UIManager.Instance.EnablePauseScreen();
	}

	public void ResumeGame()
    {
		Time.timeScale = 1;
		UIManager.Instance.DisablePauseScreen();
	}

	public void EndGame()
    {
		Time.timeScale = 0;
		SpawnSystem.Instance.EndSpawning();
		UIManager.Instance.EnableGameOverScreen();
		UIManager.Instance.GameOverPointsText(points);
	}

	public void RestartGame()
    {
		UIManager.Instance.DisableGameOverScreen();
		ResetPoints();
		Time.timeScale = 1;
		points = 0;
		SpawnSystem.Instance.StartSpawning();
	}

}