using UnityEngine;
using System.Collections;

public class SlothSelfieCameraButton : MonoBehaviour {
    public SlothSelfieCharacterController slothCharacter;
    bool buttonPressed = false;
    void OnMouseDown()
    {
        if (buttonPressed == false)
        {
            slothCharacter.CameraButtonPressed();
            buttonPressed = true;
        }
    }
}
