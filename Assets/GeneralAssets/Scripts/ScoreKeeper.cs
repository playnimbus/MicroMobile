using UnityEngine;
using System.Collections;

public static class ScoreKeeper : object {

    public static bool GameStarted = false;

    static int currentHealth;
    static int score = 0;
    static float currentGameSpeed = 1;
    static int currentDifficultyLevel = 1;

    static MenuStates menuState;

    static HealthBarBattery healthBar;
    static TextMesh ScoreLabel;

    static public void initScoreKeeper()
    {
        menuState = GameObject.Find("GameManager").GetComponent<MenuStates>();
        currentHealth = 4;
        score = 0;
        currentGameSpeed = 1;
        currentDifficultyLevel = 1;
        GameStarted = false;

        healthBar = GameObject.Find("HealthBarBattery").GetComponent<HealthBarBattery>();
        ScoreLabel = GameObject.Find("ScoreLabel").GetComponent<TextMesh>();
        ScoreLabel.text = "Score:" + score.ToString();
        healthBar.setIcon(currentHealth);
    }
    static public void GameWon()
    {
        GameStarted = false;
        score++;
        ScoreLabel.text = "Score:" + score.ToString();
        Camera.main.GetComponent<CameraTween>().TweenToHomeScreen();
    }
    static public void GameFailed()
    {
        GameStarted = false;
        currentHealth--;
        healthBar.setIcon(currentHealth);
        Camera.main.GetComponent<CameraTween>().TweenToHomeScreen();
    }
}
