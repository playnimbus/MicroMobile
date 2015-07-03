using UnityEngine;
using System.Collections;

public class MenuStates : MonoBehaviour {

    public GameObject[] minigames;

    public GameObject miniGameLocation;

    public enum ScreenStates {MainMenu, HomeScreen, GameScreen };
    public ScreenStates CurrentScreenState = ScreenStates.MainMenu;

    Camera MainCamera;

    public GameObject currentMiniGame;

	// Use this for initialization
	void Start () {
        MainCamera = Camera.main;
        CurrentScreenState = ScreenStates.MainMenu;
	}
	
	// Update is called once per frame
	void Update () {
        switch (CurrentScreenState)
        {
            case ScreenStates.MainMenu: UpdateMainMenu(); break;
            case ScreenStates.HomeScreen: UpdateHomeScreen(); break;
            case ScreenStates.GameScreen: UpdateGameScreen(); break;
        }
	}

    public void SwitchState(ScreenStates newState)
    {
        switch (CurrentScreenState)
        {
            case ScreenStates.MainMenu: ExitMainMenu(); break;
            case ScreenStates.HomeScreen: ExitHomeScreen(); break;
            case ScreenStates.GameScreen: ExitGameScreen(); break;
        }

        CurrentScreenState = newState;

        switch (CurrentScreenState)
        {
            case ScreenStates.MainMenu: EnterMainMenu(); break;
            case ScreenStates.HomeScreen: EnterHomeScreen(); break;
            case ScreenStates.GameScreen: EnterGameScreen(); break;
        }
    }


    //----------MAIN MENU//----------

    void EnterMainMenu() { }
    void UpdateMainMenu() { }
    void ExitMainMenu() 
    {
        ScoreKeeper.initScoreKeeper();      //initialize values for new game session
    }


    //----------HOME SCREEN//----------

    float homeScreenTimer;

    void EnterHomeScreen()
    {
        homeScreenTimer = 1.5f;
        currentMiniGame = (GameObject)Instantiate (minigames[Random.Range(0, minigames.Length)], transform.position, transform.rotation);
        currentMiniGame.transform.position = miniGameLocation.transform.position;
    }
    void UpdateHomeScreen()
    {
        homeScreenTimer -= Time.deltaTime;

        if (homeScreenTimer <= 0)
        {
            MainCamera.GetComponent<CameraTween>().TweenToGameScreen();
            homeScreenTimer = 999;
        }
    }
    void ExitHomeScreen()
    {
    }


    //----------GAME SCREEN//----------
    void EnterGameScreen() 
    {
        ScoreKeeper.GameStarted = true;
    }
    void UpdateGameScreen() { }
    void ExitGameScreen() 
    {
        Destroy(currentMiniGame);
    }
}
