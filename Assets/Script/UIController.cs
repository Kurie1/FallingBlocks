using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public GameController GameControllerScript;
    public TMP_Text scoreText;

    private float scoreCounter = 0;
    
    void Start()
    {
        GameControllerScript.OnGameLose += OnGameLose;
        GameControllerScript.OnGameRestart += OnGameRestart;
        scoreCounter = 0;
    }
    private void Update()
    {
        scoreCounter += Time.deltaTime;
    }

    private void OnGameRestart()
    {
        GameLose(false);
    }

    private void OnGameLose()
    {
        GameLose(true);
    }

    private void GameLose(bool isGameLose)
    {
        CanvasGroup canvasGroup = this.GetComponent<CanvasGroup>();
        if (isGameLose)
        {
            canvasGroup.alpha = 1;
            scoreText.text = scoreCounter.ToString();
        }
        else
        {
            canvasGroup.alpha = 0;
            scoreCounter = 0;
        }
    }
}
