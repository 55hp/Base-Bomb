using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{

    [SerializeField] Text pointsText;

    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Text gameOverPointsText;

    [SerializeField] Camera _myCamera;

    private void Start()
    {
        float orthoSize = 5;
        _myCamera.orthographicSize = orthoSize;
    }


    public void EnableStartScreen()
    {
        startScreen.SetActive(true);
    }

    public void DisableStartScreen()
    {
        startScreen.SetActive(false);
    }

    public void EnablePauseScreen()
    {
        pauseScreen.SetActive(true);
    }

    public void DisablePauseScreen()
    {
        pauseScreen.SetActive(false);
    }

    public void EnableGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void DisableGameOverScreen()
    {
        gameOverScreen.SetActive(false);
    }

    public void RefreshPointsText(int points)
    {
        pointsText.text = ""+  points;
    }

    public void GameOverPointsText(int points)
    {
        if (points == 1)
        {
            gameOverPointsText.text = "GAME-OVER\nHai totalizzato: 1 punt0!";
        }
        else
        gameOverPointsText.text = "GAME-OVER\nHai totalizzato: "+ points + " punti!";
    }

    
}
