using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<Player>())
        {
            EventManager.RaiseEventCoinCollected();
            Destroy(gameObject);
        }
    }
}
