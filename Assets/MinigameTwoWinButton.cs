using UnityEngine;
using System.Collections;

public class MinigameTwoWinButton : MonoBehaviour
{


    void OnMouseDown()
    {
        print("Button pressed");
        ScoreKeeper.GameWon();
    }
}
