using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContainer : MonoBehaviour
{
    public static int Coins = 0;

    [SerializeField] private int coinValue=1;

    private void Awake()
    {
        EventManager.EventGameOver += OnGameOver;
        EventManager.EventCoinCollected += OnCoinCollected;
    }

    private void OnGameOver()
    {
        PlayerPrefsManager.SetNumberOfCoins(PlayerPrefsManager.GetNumberOfCoins() + Coins);
    }

    private void OnCoinCollected()
    {
        Coins += coinValue;
    }

    private void OnDestroy()
    {
        EventManager.EventGameOver -= OnGameOver;
        EventManager.EventCoinCollected -= OnCoinCollected;
        Coins = 0;
    }
}
