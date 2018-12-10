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
    public bool isPlaying = false;

    private void Awake()
    {
        EventManager.EventMenuLoaded += OnMenuLoaded;
        EventManager.EventGameStarted += OnGameStarted;
        EventManager.EventGameOver += OnGameOver;
    }

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Spike")
        {
            EventManager.RaiseEventGameOver();
        }

        if(collision.tag == "Wall")
        {
            rigidBody.velocity = speed * (direction + Vector3.up) + new Vector3(0f, 0f, offsetZAxis);
            if (speed > 8f)
            { speed -= 1f; }
            direction = -direction;
        }
    }

    private void Update()
    {
        SetTouchArea();

        if(Input.GetMouseButtonDown(0) && isPlaying)
        {
            rigidBody.velocity = -20f * direction;
            speed += 1f;
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
        rigidBody = GetComponent<Rigidbody2D>();
        direction = Vector3.right;
        rigidBody.velocity = speed * (direction + Vector3.up) + new Vector3(0f, 0f, offsetZAxis);
        direction = -direction;

        animator.SetTrigger("GameStart");

        EventManager.EventGameStarted -= OnGameStarted;
    }

    private void OnGameOver()
    {
        rigidBody.velocity = Vector3.zero;
        EventManager.EventGameOver -= OnGameOver;
    }

    private void OnMenuLoaded()
    {
        EventManager.EventMenuLoaded -= OnMenuLoaded;
    }
}
