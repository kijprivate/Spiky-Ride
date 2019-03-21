using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawnerLevels : MonoBehaviour
{
    [SerializeField] GameObject[] chunks;
    [SerializeField] GameObject endLevelCollider;
    [SerializeField] float spawnNextChunk = 6f;
    [SerializeField] int numberOfChunks = 3;

    int randomChunk;
    Vector3 newChunkPos;

    private void Awake()
    {
        for(int i=1;i<=numberOfChunks;i++)
        {
            spawnNextChunk += 20f;
            newChunkPos = new Vector3(0f, spawnNextChunk, 0f);

            randomChunk = Random.Range(0, chunks.Length);
            Instantiate(chunks[randomChunk], newChunkPos, Quaternion.identity);
        }
        spawnNextChunk += 10f;
        newChunkPos = new Vector3(0f, spawnNextChunk, 0f);
        Instantiate(endLevelCollider, newChunkPos, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
