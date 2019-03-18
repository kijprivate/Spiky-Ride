using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Transform playerCashedTransform;
    [SerializeField]
    float speed = 10f;

    Vector3 destination;
    Transform myTransform;
    bool isFollowing = true;

    private void Awake()
    {
        myTransform = transform;
        EventManager.EventGameOver += OnGameOver;
    }

    void Update()
    {
        if(!isFollowing)
        { return; }

        destination = new Vector3(0f, playerCashedTransform.position.y,-1f);
        myTransform.position = Vector3.Lerp(myTransform.position, destination, speed * Time.deltaTime);
    }

    void OnGameOver()
    {
        isFollowing = false;
    }

    private void OnDestroy()
    {
        EventManager.EventGameOver -= OnGameOver;
    }
}
