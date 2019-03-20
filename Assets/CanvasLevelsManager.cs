using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLevelsManager : MonoBehaviour
{
    [SerializeField] GameObject EndlessModeButton;

    private void Awake()
    {
        EventManager.EventGameStarted += OnGameStarted;
    }

    void OnGameStarted()
    {
        EndlessModeButton.SetActive(false);
    }

    private void OnDestroy()
    {
        EventManager.EventGameStarted -= OnGameStarted;
    }
}
