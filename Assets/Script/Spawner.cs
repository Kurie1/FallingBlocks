using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject FallingBlockPrefab;
    public float SecondBetweenSpawns = 0.5f;
    public float Range = -2.5f;

    private float nextSpawnTime;
    
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + SecondBetweenSpawns;
            Vector2 SpawnPosition = new Vector2(Random.Range(-Range, Range), transform.position.y);
            Instantiate(FallingBlockPrefab, SpawnPosition, Quaternion.identity);
        }
    }
}
