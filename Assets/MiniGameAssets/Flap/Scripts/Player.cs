using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    bool gameOver;
    float gameTimer;
    public float winTime;
    // Use this for initialization
    void Start()
    {
        gameTimer = 0f;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreKeeper.GameStarted)
        {
            UpdateStartedGame();
        }
    }

    void UpdateStartedGame()
    {
        gameTimer += Time.deltaTime;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 250f);
        }

        if (gameTimer >= winTime)
        {
            gameOver = true;
            ScoreKeeper.GameWon();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Fail" && !gameOver)
        {
            gameOver = true;
            ScoreKeeper.GameFailed(); 
        }
        if (col.gameObject.tag == "Win" && !gameOver)
        {
            gameOver = true;
            ScoreKeeper.GameWon();
        }
    }
}
