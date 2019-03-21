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
    }

    private void OnDestroy()
    {
        EventManager.EventGameStarted -= OnGameStarted;
        EventManager.EventEndLevel -= OnEndLevel;
    }
}
