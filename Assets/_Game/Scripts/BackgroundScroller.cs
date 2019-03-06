using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    float backgroundScrollSpeed = 0.5f;
    Ball ball;
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
        ball = FindObjectOfType<Ball>();
 
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    void Update()
    {
        if (!scrollBackground) { return; }
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
        backgroundScrollSpeed = ball.GetComponent<Rigidbody2D>().velocity.y;
        print(ball.GetComponent<Rigidbody2D>().velocity.normalized.y);
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
