using UnityEngine;
using System.Collections;

public class SlothSelfieCharacterController : MonoBehaviour {

    public GameObject Background;
    public GameObject WinFace;
    public GameObject LossFace;

    float miniGameTimer = 4f;
    bool initGameValues = false;

    bool gameWon = false;
    public bool inFrame = false;

    Vector3 originalSlothPosition;
    Vector3 originalAccelPosition;
    Vector3 originalBackgroundPosition;


    float smoothTime = 0.1F;
    float yVelocity = 0.0F;
    float xVelocity = 0.0F;

    float yVelocityBackground = 0.0F;
    float xVelocityBackground = 0.0F;
	
	// Update is called once per frame
	void Update () {
        if (ScoreKeeper.GameStarted)
        {
            UpdateStartedGame();
        }
    }

    void UpdateStartedGame()
    {
        if (initGameValues == false)
        {
            originalSlothPosition = gameObject.transform.position;
            originalBackgroundPosition = Background.transform.localPosition;
            originalAccelPosition = Input.acceleration;
            initGameValues = true;
        }

        HandleMovement();

        miniGameTimer -= Time.deltaTime;
        if (miniGameTimer <= 0)
        {
            GameOver();
        }
    }

    void HandleMovement()
    {
        //Sloth Position
        float newPositionY = Mathf.SmoothDamp(gameObject.transform.position.y, originalSlothPosition.y - ((Input.acceleration.y - originalAccelPosition.y) * 5), ref yVelocity, smoothTime);
        float newPositionX = Mathf.SmoothDamp(gameObject.transform.position.x, originalSlothPosition.x - ((Input.acceleration.x - originalAccelPosition.x) * 5), ref xVelocity, smoothTime);

   //     gameObject.GetComponent< .transform.localPosition = new Vector3(newPositionX, newPositionY, originalSlothPosition.z);
        gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(newPositionX,newPositionY));

        //Background position
        newPositionY = Mathf.SmoothDamp(Background.transform.localPosition.y, originalBackgroundPosition.y - ((Input.acceleration.y - originalAccelPosition.y) * 9), ref yVelocityBackground, smoothTime);
        newPositionX = Mathf.SmoothDamp(Background.transform.localPosition.x, originalBackgroundPosition.x - ((Input.acceleration.x - originalAccelPosition.x) * 9), ref xVelocityBackground, smoothTime);

        Background.transform.localPosition = new Vector3(newPositionX, newPositionY, originalBackgroundPosition.z);
	
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

    public void CameraButtonPressed()
    {
        if (inFrame)
        {
            gameWon = true;
            WinFace.SetActive(true);
        }
        else
        {
            LossFace.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        inFrame = true;
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        inFrame = false;
    }
}
