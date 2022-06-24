using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
   

    public GameObject SpawnerObject;
    public GameObject GameOverUI;
    public GameObject Player;
   

    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (this.enabled == true)
        {
            LoseGame();
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            StartGame();
        }
        
    }
    
   
    private void LoseGame()
    {
        Spawner spawner = SpawnerObject.GetComponent<Spawner>();
        spawner.enabled = false;


        CanvasGroup canvasGroup = GameOverUI.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;

        PlayerMovement player = Player.GetComponent<PlayerMovement>();
        player.enabled = false;

        
       
    }
    private void StartGame()
    {

        Spawner spawner = SpawnerObject.GetComponent<Spawner>();
        spawner.enabled = true;

        CanvasGroup canvasGroup = GameOverUI.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;

        PlayerMovement player = Player.GetComponent<PlayerMovement>();
        player.enabled = true;

        this.enabled = false;

    }
}
