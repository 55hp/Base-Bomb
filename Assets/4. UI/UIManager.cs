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
        StartCoroutine(OpenScreen(startScreen));
    }

    public void DisableStartScreen()
    {
        StartCoroutine(CloseScreen(startScreen));
    }

    public void EnablePauseScreen()
    {
        StartCoroutine(OpenScreen(pauseScreen));
    }

    public void DisablePauseScreen()
    {
        StartCoroutine(CloseScreen(pauseScreen));
    }

    public void EnableGameOverScreen()
    {
        StartCoroutine(OpenScreen(gameOverScreen));
    }

    public void DisableGameOverScreen()
    {
        StartCoroutine(CloseScreen(gameOverScreen));
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

    IEnumerator OpenScreen(GameObject screen)
    {
        yield return new WaitForSecondsRealtime(.5f);
        screen.SetActive(true);
    }

    IEnumerator CloseScreen(GameObject screen)
    {
        yield return new WaitForSecondsRealtime(.5f);
        screen.SetActive(false);
    }
}
