using UnityEngine;
using System.Collections;

public class CameraTween : MonoBehaviour {

    public GameObject MainMenuPosition;
    public GameObject HomeScreenPosition;
    public GameObject GameScreenPosition;


	// Use this for initialization
	void Start () {
        gameObject.transform.position = MainMenuPosition.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TweenToHomeScreen(){

         Hashtable hashtable = new Hashtable();
         hashtable.Add("position", HomeScreenPosition.transform.position);
         hashtable.Add("speed", 7);
         hashtable.Add("easetype", iTween.EaseType.easeOutExpo);
         hashtable.Add("oncomplete", "switchMenuToHomeScreen");

         iTween.MoveTo(gameObject, hashtable);
    }

    void switchMenuToHomeScreen()
    {
        GameObject.Find("GameManager").GetComponent<MenuStates>().SwitchState(MenuStates.ScreenStates.HomeScreen);
    }

    public void TweenToGameScreen()
    {
        Hashtable hashtable = new Hashtable();
        hashtable.Add("position", GameScreenPosition.transform.position);
        hashtable.Add("speed", 7);
        hashtable.Add("easetype", iTween.EaseType.easeOutExpo);
        hashtable.Add("oncomplete", "switchMenuToGameScreen");

        iTween.MoveTo(gameObject, hashtable);
    }

    void switchMenuToGameScreen()
    {
        GameObject.Find("GameManager").GetComponent<MenuStates>().SwitchState(MenuStates.ScreenStates.GameScreen);
    }
}
