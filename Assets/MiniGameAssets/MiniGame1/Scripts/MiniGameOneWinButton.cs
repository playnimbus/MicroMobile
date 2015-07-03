using UnityEngine;
using System.Collections;

public class MiniGameOneWinButton : MonoBehaviour {


    void OnMouseDown()
    {
        print("Button pressed");
        ScoreKeeper.GameWon();
    }
}
