using UnityEngine;
using System.Collections;

public static class ScoreKeeper : object {

    public static bool GameStarted = false;

    static int currentHealth;
    static int score = 0;

    static float currentGameSpeed = 1;
    static int countTillSpeedIncrease = 3;
    static float gameSpeedIncreaseAmount = 0.1f;
    
    static int currentDifficultyLevel = 1;
    static int countTillDifficultyIncrease = 4;

    static MenuStates menuState;

    static HealthBarBattery healthBar;
    static TextMesh ScoreLabel;

    /// <summary>
    /// Sets up the score keeper for the start of the game. sets all values to default. Call this when starting a new game
    /// </summary>
    static public void initScoreKeeper()
    {
        menuState = GameObject.Find("GameManager").GetComponent<MenuStates>();
        currentHealth = 4;
        score = 0;
        currentGameSpeed = 1;
        currentDifficultyLevel = 1;
        GameStarted = false;
        Time.timeScale = currentGameSpeed;


        healthBar = GameObject.Find("HealthBarBattery").GetComponent<HealthBarBattery>();
        ScoreLabel = GameObject.Find("ScoreLabel").GetComponent<TextMesh>();
        ScoreLabel.text = "Score:" + score.ToString();
        healthBar.setIcon(currentHealth);
    }

    static void checkForDifficultyAndSpeedChange()
    {
        if (currentDifficultyLevel < 8) //check for difficulty increase
        {
            countTillDifficultyIncrease--;
            if (countTillDifficultyIncrease <= 0)
            {
                currentDifficultyLevel++;
                countTillDifficultyIncrease = 4;
                Debug.Log("Difficulty Increased to: " + currentDifficultyLevel);
            }
        }

        countTillSpeedIncrease--;
        if (countTillSpeedIncrease <= 0)
        {
            currentGameSpeed += gameSpeedIncreaseAmount;
            Time.timeScale = currentGameSpeed;
            countTillSpeedIncrease = 3;
            Debug.Log("Speed Increased to: " + currentGameSpeed);
        }
    }

    /// <summary>
    /// Called to end a minigame as a win. This should only be called once in a minigame and will immediatly begin the transition back to the homescreen.
    /// </summary>
    static public void GameWon()
    {
        GameStarted = false;
        score++;
        ScoreLabel.text = "Score:" + score.ToString();
        Camera.main.GetComponent<CameraTween>().TweenToHomeScreen();
        checkForDifficultyAndSpeedChange();

    }

    /// <summary>
    /// Called to end a minigame as a loss. This should only be called once in a minigame and will immediatly begin the transition back to the homescreen. 
    /// </summary>
    static public void GameFailed()
    {
        GameStarted = false;
        currentHealth--;
        score++;
        healthBar.setIcon(currentHealth);
        Camera.main.GetComponent<CameraTween>().TweenToHomeScreen();
        checkForDifficultyAndSpeedChange();
    }

    /// <summary>
    /// Returns minigame difficulty level(1,2,3) based off the the probability defined in the ScoreKeeper.
    /// </summary>
    static public int getCurrentDiffictuly(){

        int randomNum = Random.Range(1, 5);
        

        switch (currentDifficultyLevel)
        {
            case 1:
                return 1;   //1: 100
                break;

            case 2:
                switch (randomNum) //1: 75%     2: 25%
                {
                    case 1: return 1; break;
                    case 2: return 1; break;
                    case 3: return 1; break;
                    case 4: return 2; break;
                }
                break;

            case 3:
                switch (randomNum)//1: 50%     2: 50%
                {
                    case 1: return 1; break;
                    case 2: return 1; break;
                    case 3: return 2; break;
                    case 4: return 2; break;
                }
                break;

            case 4:
                switch (randomNum)//1: 25%     2: 50%       3: 25%
                {
                    case 1: return 1; break;
                    case 2: return 2; break;
                    case 3: return 2; break;
                    case 4: return 3; break;
                }
                break;

            case 5:
                switch (randomNum)//1: 0%     2: 75%       3: 25%
                {
                    case 1: return 2; break;
                    case 2: return 2; break;
                    case 3: return 2; break;
                    case 4: return 3; break;
                }
                break;

            case 6:
                switch (randomNum)//1: 0%     2: 50%       3: 50%
                {
                    case 1: return 2; break;
                    case 2: return 2; break;
                    case 3: return 3; break;
                    case 4: return 3; break;
                }
                break;

            case 7:
                switch (randomNum)//1: 0%     2: 25%       3: 75%
                {
                    case 1: return 2; break;
                    case 2: return 3; break;
                    case 3: return 3; break;
                    case 4: return 3; break;
                }
                break;

            case 8:
                return 3; //1: 0%     2: 0%       3: 100%
                break;
        }
        return 1;

    }

}
