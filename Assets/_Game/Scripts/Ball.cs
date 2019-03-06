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
    public bool isPlaying = false;

    private void Awake()
    {
        EventManager.EventMenuLoaded += OnMenuLoaded;
        EventManager.EventGameStarted += OnGameStarted;
        EventManager.EventGameOver += OnGameOver;
    }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInParent<Animator>();
        rigidBody.gravityScale = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Spike")
        {
            EventManager.RaiseEventGameOver();
        }

        if(collision.tag == "Wall")
        {
            //rigidBody.AddForce(Vector2.up * speed);
            //rigidBody.velocity = speed * (direction + Vector3.up) + new Vector3(0f, 0f, offsetZAxis);
            //if (speed > 8f)
            //{ speed -= 1f; }
            //direction = -direction;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            animator.SetTrigger("WallCollision");
            rigidBody.AddForce(Vector3.up * speed*45f+ direction*speed*10f);
            direction = -direction;
        }

    }

    private void Update()
    {
        SetTouchArea();

        if(Input.GetMouseButtonDown(0) && isPlaying)
        {
            // rigidBody.velocity = -20f * direction;
            rigidBody.AddForce(-Vector3.up - direction * speed * 100f);
            speed += 1f;
        }
        lookDirection = rigidBody.velocity.normalized;
        Vector3 test = new Vector3(0f, 0f, lookDirection.x);
        transform.rotation = Quaternion.LookRotation(test);
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
        rigidBody.velocity = speed * (direction + Vector3.up) + new Vector3(0f, 0f, offsetZAxis);
        direction = -direction;

        //rigidBody.gravityScale = 0.5f;

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
