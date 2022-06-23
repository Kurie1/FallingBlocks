using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float bound;
    private float objectScale;

    public float PlayerSpeed = 5f;

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

        
    }


    private void LoseGame()
    {

    }
}
