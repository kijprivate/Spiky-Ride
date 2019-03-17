using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed = 8f;

    [SerializeField]
    float offsetZAxis = 2f;

    Rigidbody2D rigidBody;
    Animator animator;
    Vector3 direction;
    Vector3 lookDirection;
    bool clicked;
    public bool isPlaying = false;

    private void Awake()
    {
        EventManager.EventMenuLoaded += OnMenuLoaded;
        EventManager.EventGameStarted += OnGameStarted;
        EventManager.EventGameOver += OnGameOver;
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
        SetTouchArea();

        if(isPlaying && !clicked)
        {
            transform.position += (direction+Vector3.up)*Time.deltaTime * speed;
        }
        else if(isPlaying && clicked)
        {
            transform.position += direction * Time.deltaTime * speed*3;
        }
        if(Input.GetMouseButtonDown(0) && isPlaying)
        {
            clicked = true;
            speed += 0.2f;
        }
    }

    private void SetTouchArea()
    {
        if (isPlaying) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.y > 0.3 * Screen.height)
            {
                EventManager.RaiseEventGameStarted();
                isPlaying = true;
            }
        }
    }

    private void OnGameStarted()
    {
        direction = Vector3.right;

        EventManager.EventGameStarted -= OnGameStarted;
    }

    private void OnGameOver()
    {
       // rigidBody.velocity = Vector3.zero;
        EventManager.EventGameOver -= OnGameOver;
    }

    private void OnMenuLoaded()
    {
        EventManager.EventMenuLoaded -= OnMenuLoaded;
    }

    public void ClearEvent()
    {
        EventManager.EventGameOver -= OnGameOver;
        //EventManager.EventGameResumed -= OnGameResumed;
    }
}
