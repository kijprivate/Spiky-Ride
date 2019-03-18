using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    GameObject MenuUI;

    [SerializeField]
    GameObject GameplayUI;

    [SerializeField]
    Text gamesPlayed;

    [SerializeField]
    Text highScore;

    [SerializeField]
    Text scoreGameplay;

    Player player;

    private void Awake()
    {
        EventManager.EventGameStarted += OnGameStarted;
        EventManager.EventGameOver += OnGameOver;

        gamesPlayed.text = "GAMES PLAYED: " + PlayerPrefsManager.GetGamesPlayed().ToString();
        highScore.text = "HIGH SCORE: " + PlayerPrefsManager.GetHighScore().ToString();

        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        scoreGameplay.text = player.Distance.ToString();
    }
    private void OnGameOver()
    {
        //if (countDistance > PlayerPrefsManager.GetHighScore())
        //{ PlayerPrefsManager.SetHighScore(countDistance); }

        //if (countDistance > 10f && !progresBarShowed)
        //{
        //    progressBar.SetActive(true);
        //    progresBarShowed = true;
        //}
        //else if (countDistance < 10f || progresBarShowed)
        //{ gameOverPanel.SetActive(true); }

        gameOverPanel.SetActive(true);
    }

    private void OnGameStarted()
    {
        MenuUI.SetActive(false);
        GameplayUI.SetActive(true);
    }

    private void OnDestroy()
    {
        EventManager.EventGameOver -= OnGameOver;
        EventManager.EventGameStarted -= OnGameStarted;
    }
}
