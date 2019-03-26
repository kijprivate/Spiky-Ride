using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelContainer : MonoBehaviour
{
    public static int Coins = 0;
    public static int coinsReward;

    [SerializeField] private int coinValue=1;
    [SerializeField] public static int keysForLevel = 1;
    [SerializeField] public static int minCoinsForLevel = 1;
    [SerializeField] public static int maxCoinsForLevel = 5;
    [SerializeField] public static int goldChestForLevel = 0;
    [SerializeField] public static int platChestForLevel = 0;

    private void Awake()
    {
        EventManager.EventGameOver += OnGameOver;
        EventManager.EventCoinCollected += OnCoinCollected;
        EventManager.EventEndLevel += OnEndLevel;
        print(keysForLevel);
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
        coinsReward = Random.Range(minCoinsForLevel, maxCoinsForLevel + 1);

        PlayerPrefsManager.SetNumberOfCoins(PlayerPrefsManager.GetNumberOfCoins() + Coins + coinsReward);
        if(!PlayerPrefsManager.IsLevelUnlocked(SceneManager.GetActiveScene().buildIndex + 1))
        {
            PlayerPrefsManager.UnlockLevel(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefsManager.SetNumberOfKeys(PlayerPrefsManager.GetNumberOfKeys() + keysForLevel);
            PlayerPrefsManager.SetNumberOfGoldChests(PlayerPrefsManager.GetNumberOfGoldChests() + goldChestForLevel);
            PlayerPrefsManager.SetNumberOfPlatChests(PlayerPrefsManager.GetNumberOfPlatChests() + platChestForLevel);
        }
        else
        {
            keysForLevel = 0;
            goldChestForLevel = 0;
            platChestForLevel = 0;
        }
    }

    private void OnDestroy()
    {
        EventManager.EventGameOver -= OnGameOver;
        EventManager.EventCoinCollected -= OnCoinCollected;
        EventManager.EventEndLevel -= OnEndLevel;
        Coins = 0;
    }
}
