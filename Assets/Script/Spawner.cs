using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject FallingBlockPrefab;
    public float secondbetweenSpawns = 0.5f;
    float nextSpawnsTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnsTime)
        {
            nextSpawnsTime = Time.time + secondbetweenSpawns;
            Vector2 SpawnPosition = new Vector2(Random.Range(-2.5f, 2.5f), 7);
            Instantiate(FallingBlockPrefab, SpawnPosition, Quaternion.identity);
        }
    }
}
