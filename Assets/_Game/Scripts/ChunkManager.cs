using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{

    public GameObject[] chunks;
    public float spawnNextChunk = 6f;
    public int numberOfChunks = 0;

    Ball ball;
    int randomChunk;
    Vector3 newChunkPos;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {

        if (numberOfChunks < 4 && ball.isPlaying)
        {
            spawnNextChunk += 10f;
            newChunkPos = new Vector3(0f, spawnNextChunk,0f);

            randomChunk = Random.Range(0, chunks.Length);
            // print(randomChunk);
            Instantiate(chunks[randomChunk], newChunkPos, Quaternion.identity);
            numberOfChunks += 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        Destroy(other.gameObject);
        numberOfChunks--;
    }
}
