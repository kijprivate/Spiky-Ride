using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    float speed = 10f;

    Vector3 destination;

    void Update()
    {
        destination = new Vector3(0f, player.transform.position.y,-1f);

        transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
    }
}
