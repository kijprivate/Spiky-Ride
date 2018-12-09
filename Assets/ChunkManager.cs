using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{

    public GameObject[] chunks;
    public float spawnNextChunk = 12f;
    public int numberOfChunks = 0;

    Ball ball;
    int randomChunk;
    Vector2 newChunkPos;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {

        if (numberOfChunks < 2 && ball.isPlaying)
        {
            spawnNextChunk += 10f;
            newChunkPos = new Vector2(0f, spawnNextChunk);

            randomChunk = Random.Range(0, chunks.Length);
            // print(randomChunk);
            Instantiate(chunks[randomChunk], newChunkPos, Quaternion.identity);
            numberOfChunks += 1;
        }
    }
}
