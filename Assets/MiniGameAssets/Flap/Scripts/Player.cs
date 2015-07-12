using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    bool gameFail;
    float gameTimer;
    public float winTime;
    public float maxVelocity;
    public float jumpVelocity;
    public int difficutly; //don't leave public in final code
    public bool debugLevel; //debug option to stop levels from spawning when developing new ones.

    public GameObject[] levels;
    // Use this for initialization
    void Start()
    {
        gameTimer = 0f;
        gameFail = false;
        //ScoreKeeper.GameStarted = true; 
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
        if (!debugLevel)
        {
            switch (difficutly)
            {
                case 0:
                    levels[difficutly].SetActive(true);
                    winTime = 5f;
                    break;
                case 1:
                    levels[difficutly].SetActive(true);
                    winTime = 6f;
                    break;
                case 2:
                    levels[difficutly].SetActive(true);
                    winTime = 8.5f;
                    break;
            }
        }

        

        if (Input.GetMouseButtonDown(0) && !gameFail)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpVelocity);
            
        }
        //Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y >= maxVelocity)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, maxVelocity);
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
