using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField, Tooltip("Child of this canvas object")]
    Text gemsText;

    [SerializeField, Tooltip("Child of this canvas object")]
    Text gamesPlayed;

    [SerializeField, Tooltip("Child of this canvas object")]
    Text highScore;

    Animator animator;

    private void Awake()
    {
        EventManager.EventGameStarted += OnGameStarted;
        EventManager.EventGameOver += OnGameOver;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMenuLoaded()
    {
        // Display UI values
        gemsText.text = PlayerPrefsManager.GetNumberOfGems().ToString();
        gamesPlayed.text = "GAMES PLAYED: " + PlayerPrefsManager.GetGamesPlayed().ToString();
        highScore.text = "HIGH SCORE: " + PlayerPrefsManager.GetHighScore().ToString();

        EventManager.EventMenuLoaded -= OnMenuLoaded;
    }

    private void OnGameOver()
    {
        PlayerPrefsManager.SetGamesPlayed(PlayerPrefsManager.GetGamesPlayed() + 1);
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

        EventManager.EventGameOver -= OnGameOver;
    }

    private void OnGameStarted()
    {
        animator.SetTrigger("FadeOut");
        EventManager.EventGameStarted -= OnGameStarted;
    }

    public void ClearEvent()
    {
        EventManager.EventGameOver -= OnGameOver;
        //EventManager.EventGameResumed -= OnGameResumed;
    }
}
