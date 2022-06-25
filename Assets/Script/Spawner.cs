using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject FallingBlockPrefab;
    public float SecondBetweenSpawns = 0.5f;
    public float Range = -2.5f;
    public GameController GameControllerScript;

    private bool isLoseGame;
    private float nextSpawnTime;
    private float bottomBound;
    private Queue<GameObject> spawnBlocks;

    private void Awake()
    {
        spawnBlocks = new Queue<GameObject>();
    }

    private void Start()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        bottomBound =-( height / 2);




        GameControllerScript.OnGameLose += OnGameLose;
        GameControllerScript.OnGameRestart += OnGameRestart;
    }

    private void OnGameRestart()
    {
        isLoseGame = false;
    }

    private void OnGameLose()
    {
        isLoseGame = true;
    }

    void Update()
    {
        if (spawnBlocks.Count != 0)
        {
            GameObject firstBlock = spawnBlocks.Peek();
            if (firstBlock.transform.position.y < bottomBound)
            {
                spawnBlocks.Dequeue();
                Destroy(firstBlock);
            }
        }

        if (isLoseGame)
            return;

        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + SecondBetweenSpawns;
            Vector2 SpawnPosition = new Vector2(UnityEngine.Random.Range(-Range, Range), transform.position.y);
            GameObject block = Instantiate(FallingBlockPrefab, SpawnPosition, Quaternion.identity);
            spawnBlocks.Enqueue(block);
        }
    }
}
