using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    bool gameFail;
    float gameTimer;
    public float winTime;
    // Use this for initialization
    void Start()
    {
        gameTimer = 0f;
        gameFail = false;
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
        if (Input.GetMouseButtonDown(0) && !gameFail)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 250f);
        }

        if (gameTimer >= winTime)
        {
            if (!gameFail)
            ScoreKeeper.GameWon();
            else
            {
                ScoreKeeper.GameFailed();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Fail")
        {
            gameFail = true;
        }
    }
}
