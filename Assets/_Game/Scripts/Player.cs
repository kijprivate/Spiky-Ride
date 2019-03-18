using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ControlFreak2;

public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 8f;

    [SerializeField]
    float speedIncrementation = 0.2f;

    [SerializeField]
    float maxSpeed = 15f;

    private Transform cashedTransform;

    private int distance;
    public int Distance { get { return distance; } }

    Vector3 direction;
    bool clicked;
    bool isPlaying = false;

    private void Awake()
    {
        EventManager.EventGameStarted += OnGameStarted;
        EventManager.EventGameOver += OnGameOver;

        cashedTransform = transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Spike")
        {
            EventManager.RaiseEventGameOver();
        }

        if(collision.tag == "Wall")
        {
            direction = -direction;
            clicked = false;
        }
    }

    private void Update()
    {
        distance = (int)cashedTransform.position.y;

        if(CF2Input.GetButtonDown("Click") && !isPlaying)
        { EventManager.RaiseEventGameStarted(); }

        if(isPlaying && !clicked)
        {
            cashedTransform.position += (direction+Vector3.up)*Time.deltaTime * speed;
        }
        else if(isPlaying && clicked)
        {
            cashedTransform.position += direction * Time.deltaTime * speed*3;
        }
        if(CF2Input.GetButtonDown("Click") && isPlaying)
        {
            clicked = true;
            if (speed < maxSpeed)
            {
                speed += speedIncrementation;
            }
        }
    }

    private void OnGameStarted()
    {
        direction = Vector3.right;
        isPlaying = true;
    }

    private void OnGameOver()
    {
        direction = Vector3.zero;
        PlayerPrefsManager.SetGamesPlayed(PlayerPrefsManager.GetGamesPlayed() + 1);
        if(distance > PlayerPrefsManager.GetHighScore())
        { PlayerPrefsManager.SetHighScore((float)distance); }
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EventManager.EventGameOver -= OnGameOver;
        EventManager.EventGameStarted -= OnGameStarted;
    }
}
