using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]
    float backgroundScrollSpeed = 0.5f;
    Material myMaterial;
    Vector2 offSet;
    bool scrollBackground = false;

    private void Awake()
    {
        EventManager.EventGameStarted += OnGameStarted;
        EventManager.EventGameOver += OnGameOver;
    }

    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    void Update()
    {
        if (!scrollBackground) { return; }
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }

    private void OnGameStarted()
    {
        scrollBackground = true;
        EventManager.EventGameStarted -= OnGameStarted;
    }

    private void OnGameOver()
    {
        scrollBackground = false;
        EventManager.EventGameOver -= OnGameOver;
    }
}
