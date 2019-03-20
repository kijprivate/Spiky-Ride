using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEndlessManager : MonoBehaviour
{
    [SerializeField] GameObject LevelsModeButton;

    private void Awake()
    {
        EventManager.EventGameStarted += OnGameStarted;
    }

    void OnGameStarted()
    {
        LevelsModeButton.SetActive(false);
    }

    private void OnDestroy()
    {
        EventManager.EventGameStarted -= OnGameStarted;
    }
}
