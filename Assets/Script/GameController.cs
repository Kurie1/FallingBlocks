using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerMovement playerMovementScript;

    public Action OnGameLose;
    public Action OnGameRestart;

    private void Start()
    {
        playerMovementScript.OnHit += OnHit;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartGame();
        }
    }
   
    private void OnHit()
    {
        LoseGame();
    }
    private void LoseGame()
    {
        OnGameLose?.Invoke();
    }

    private void StartGame()
    {
        OnGameRestart?.Invoke();
    }
}
