using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasEndlessManager : MonoBehaviour
{
    [SerializeField] GameObject MenuUI;
    [SerializeField] Text gamesPlayed;
    [SerializeField] Text highScore;

    private void Awake()
    {
        EventManager.EventGameStarted += OnGameStarted;

        gamesPlayed.text = "GAMES PLAYED: " + PlayerPrefsManager.GetGamesPlayed().ToString();
        highScore.text = "HIGH SCORE: " + PlayerPrefsManager.GetHighScore().ToString();
    }

    void OnGameStarted()
    {
        MenuUI.SetActive(false);
    }

    private void OnDestroy()
    {
        EventManager.EventGameStarted -= OnGameStarted;
    }
}
