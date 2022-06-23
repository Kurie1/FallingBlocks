using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float bound;
    private float objectScale;
    private bool endGame = false;

    public float PlayerSpeed = 5f;
    public GameObject SpawnerObject;
    public GameObject GameOverUI;


    void Start()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        bound = width / 2;
        objectScale= transform.localScale.x;
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && endGame == true)
        {
            StartGame();
        }

        if (endGame)
            return;
      

        if (transform.position.x + objectScale / 2 < bound)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position = Vector2.Lerp(transform.position, transform.position + transform.right, PlayerSpeed * Time.deltaTime);
            }
        }

        if (transform.position.x - objectScale / 2 > -bound)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position = Vector2.Lerp(transform.position, transform.position - transform.right, PlayerSpeed * Time.deltaTime);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoseGame();

        TMP_Text text = SpawnerObject.GetComponent<TMP_Text>();
        text.text = Time.time.ToString();
    }


    private void LoseGame()
    {
        Spawner spawner= SpawnerObject.GetComponent<Spawner>();
        spawner.enabled = false;


        CanvasGroup canvasGroup = GameOverUI.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;

        endGame = true;
    }
    private void StartGame()
    {
        endGame = false;
        Spawner spawner = SpawnerObject.GetComponent<Spawner>();
        spawner.enabled = true;
        CanvasGroup canvasGroup = GameOverUI.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;


    }
}
