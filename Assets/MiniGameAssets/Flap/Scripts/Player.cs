using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreKeeper.GameStarted)
        {
            UpdateStartedGame();
        }
    }

    void UpdateStartedGame()
    {
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Down");
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 250f);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Fail")
        {
            ScoreKeeper.GameFailed(); //TODO: Make this only happen once. 
        }
        if (col.gameObject.tag == "Win")
        {
            ScoreKeeper.GameWon();
        }
    }
}
