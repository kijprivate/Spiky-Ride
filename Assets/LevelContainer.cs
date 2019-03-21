using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelContainer : MonoBehaviour
{
    public static int Coins = 0;

    [SerializeField] private int coinValue=1;

    private void Awake()
    {
        EventManager.EventGameOver += OnGameOver;
        EventManager.EventCoinCollected += OnCoinCollected;
        EventManager.EventEndLevel += OnEndLevel;
    }

    private void OnGameOver()
    {
        PlayerPrefsManager.SetNumberOfCoins(PlayerPrefsManager.GetNumberOfCoins() + Coins);
    }

    private void OnCoinCollected()
    {
        Coins += coinValue;
    }

    private void OnEndLevel()
    {
        PlayerPrefsManager.SetNumberOfCoins(PlayerPrefsManager.GetNumberOfCoins() + Coins);
        PlayerPrefsManager.UnlockLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnDestroy()
    {
        EventManager.EventGameOver -= OnGameOver;
        EventManager.EventCoinCollected -= OnCoinCollected;
        EventManager.EventEndLevel -= OnEndLevel;
        Coins = 0;
    }
}
