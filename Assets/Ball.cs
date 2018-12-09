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
    Vector3 direction;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        direction = Vector3.right;
        rigidBody.velocity = speed * (direction + Vector3.up) + new Vector3(0f,0f,offsetZAxis);
        direction = -direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rigidBody.velocity = speed * (direction + Vector3.up) + new Vector3(0f, 0f, offsetZAxis);
        if(speed>8f)
        { speed -= 1f; }
        direction = -direction;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rigidBody.velocity = -20f * direction;
            speed += 1f;
        }
    }
}
