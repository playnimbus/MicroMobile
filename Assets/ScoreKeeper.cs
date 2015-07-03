using UnityEngine;
using System.Collections;

public static class ScoreKeeper : object {

    static int currentHealth;
    static int score = 0;
    static float currentGameSpeed = 1;
    static int currentDifficultyLevel = 1;

    static MenuStates menuState;

    static public void initScoreKeeper()
    {
        menuState = GameObject.Find("GameManager").GetComponent<MenuStates>();
        currentHealth = 4;
        score = 0;
        currentGameSpeed = 1;
        currentDifficultyLevel = 1;
    }
    static public void GameWon()
    {
        score++;
        Camera.main.GetComponent<CameraTween>().TweenToHomeScreen();
    }
    static public void GameFailed()
    {
        currentHealth--;
        Camera.main.GetComponent<CameraTween>().TweenToHomeScreen();
    }
}
