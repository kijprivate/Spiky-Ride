using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    void Update()
    {
        this.transform.position = new Vector3(0f, player.transform.position.y,0f);
    }
}
