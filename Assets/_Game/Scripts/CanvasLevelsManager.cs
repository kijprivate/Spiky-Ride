using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasLevelsManager : MonoBehaviour
{
    [SerializeField] GameObject EndlessModeButton;
    [SerializeField] GameObject EndLevelPanel;
    [SerializeField] Text LevelName;
    [SerializeField] Text coinsRewardText;
    [SerializeField] Text keysRewardText;
    [SerializeField] Text goldChestRewardText;
    [SerializeField] Text platChestRewardText;

    private void Awake()
    {
        EventManager.EventGameStarted += OnGameStarted;
        EventManager.EventEndLevel += OnEndLevel;

        LevelName.text = SceneManager.GetActiveScene().name;
    }

    void OnGameStarted()
    {
        EndlessModeButton.SetActive(false);
        LevelName.gameObject.SetActive(false);
    }

    void OnEndLevel()
    {
        EndLevelPanel.SetActive(true);
        coinsRewardText.text = LevelContainer.coinsReward.ToString();
        keysRewardText.text = LevelContainer.keysForLevel.ToString();
        goldChestRewardText.text = LevelContainer.goldChestForLevel.ToString();
        platChestRewardText.text = LevelContainer.platChestForLevel.ToString();
    }

    private void OnDestroy()
    {
        EventManager.EventGameStarted -= OnGameStarted;
        EventManager.EventEndLevel -= OnEndLevel;
    }
}
