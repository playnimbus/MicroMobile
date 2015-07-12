using UnityEngine;
using System.Collections;

public class MenuStates : MonoBehaviour
{

    public GameObject[] minigames;

    public GameObject miniGameLocation;

    public enum ScreenStates { MainMenu, HomeScreen, GameScreen };
    public ScreenStates CurrentScreenState = ScreenStates.MainMenu;

    Camera MainCamera;

    public GameObject currentMiniGame;

    GameObject notificationBar;
    notificationController notification;
    HomeScreenController homeScreenController;

    // Use this for initialization
    void Start()
    {
        MainCamera = Camera.main;
        CurrentScreenState = ScreenStates.MainMenu;

        notificationBar = GameObject.Find("notificationBar");
        notification = GameObject.Find("Notification").GetComponent<notificationController>();
        homeScreenController = GameObject.Find("HomeScreenBackground").GetComponent<HomeScreenController>();
    }

    // Update is called once per frame
    void Update()
    {
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

    bool homescreenAnimationsComplete;
    bool firstGame = true;
    void EnterHomeScreen()
    {
        notification.ResetNotificationPosition();
        if (firstGame == false)
        {
            homeScreenController.LowerNextIcon();
        }

        homescreenAnimationsComplete = false;
        currentMiniGame = (GameObject)Instantiate(minigames[Random.Range(0, minigames.Length)], transform.position, transform.rotation);
        currentMiniGame.transform.position = miniGameLocation.transform.position;

        homeScreenController.SetCurrentAppIcon(currentMiniGame.GetComponent<AppInfoContainer>().AppIcon);
        notification.setNotificationInfo(currentMiniGame.GetComponent<AppInfoContainer>());

        if (firstGame == true)
        {
            notificationBar.GetComponent<NotificationbarFade>().startFade();
            notification.TweenNotificationDown();
            firstGame = false;
        }
    }
    void UpdateHomeScreen()
    {
        if (homescreenAnimationsComplete)
        {
            MainCamera.GetComponent<CameraTween>().TweenToGameScreen();
            homescreenAnimationsComplete = false;
        }
    }
    void ExitHomeScreen()
    {
        notificationBar.GetComponent<NotificationbarFade>().resetFade();
        homescreenAnimationsComplete = false;
    }

    public void setHomeScreenAnimation(bool isComplete)
    {
        homescreenAnimationsComplete = isComplete;
    }


    //----------GAME SCREEN//----------
    void EnterGameScreen()
    {
        ScoreKeeper.GameStarted = true;
        notification.startNotificationSlideUp();
    }
    void UpdateGameScreen() { }
    void ExitGameScreen()
    {
        Destroy(currentMiniGame);
    }
}
