using UnityEngine;
using System.Collections;

public class MinigameTwoWinButton : MonoBehaviour
{
    float miniGameTimer = 2.5f;
    bool gameWon = false;

    void Update()
    {
        if (ScoreKeeper.GameStarted)
        {
            UpdateStartedGame();
        }
    }

    void UpdateStartedGame()
    {
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
