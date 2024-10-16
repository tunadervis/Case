using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText; 
    private float timeRemaining;
    private bool isGameOver = false;
    private GameSettings gameSettings;

    private void Start()
    {
        gameSettings = FindObjectOfType<GameSettings>();
        SetInitialTime();
        StartCoroutine(StartCountdown());
    }

    private void SetInitialTime()
    {
        switch (gameSettings.difficulty)
        {
            case GameSettings.Difficulty.Easy:
                timeRemaining = 15 * 60f; 
                break;
            case GameSettings.Difficulty.Medium:
                timeRemaining = 10 * 60f; 
                break;
            case GameSettings.Difficulty.Hard:
                timeRemaining = 7 * 60f; 
                break;
        }
    }

    private IEnumerator StartCountdown()
    {
        while (timeRemaining > 0 && !isGameOver)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
            yield return null;
        }

        if (timeRemaining <= 0 && !isGameOver)
        {
            GameOver();
        }
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void GameOver()
    {
        isGameOver = true;
        
        Debug.Log("Süre bitti! Oyunu kaybettin.");
        
    }
}
