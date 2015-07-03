using UnityEngine;
using System.Collections;

public class MiniGameOneWinButton : MonoBehaviour {

    float miniGameTimer = 2.5f;

    Vector3 moveSpeed = new Vector3(0, 5, 0);
    bool gameWon = false;

    void Update ()
    {
        if (ScoreKeeper.GameStarted)
        {
            UpdateStartedGame();
        }
    }

    void UpdateStartedGame()
    {
        if (gameWon == false)
        {
            gameObject.transform.position += moveSpeed * Time.deltaTime;
        }

        miniGameTimer -= Time.deltaTime;
        if (miniGameTimer <= 0)
        {
            GameOver();
        }
    }

    void OnMouseDown()
    {
        gameWon = true;
    }

    void GameOver()
    {
        if (gameWon)
        {
            ScoreKeeper.GameWon();
        }
        else
        {
            ScoreKeeper.GameFailed();
        }
    }
}
