using UnityEngine;
using System.Collections;

public class PegGame : MonoBehaviour {
    public float speed;

    public bool ismovingRight;
    public bool isFailWall;

	void Update () {
        if (ScoreKeeper.GameStarted)
        {
            UpdateStartedGame();
        }
	}

    void UpdateStartedGame()
    {
        if (!isFailWall)
        {
            MoveBall();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //ball movement (toggle between hitting walls)
        if (!isFailWall)
        {
            if (col.gameObject.tag == "ball")
            {
                ScoreKeeper.GameWon();
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
            if (ismovingRight && col.gameObject.tag == "wall")
            {
                ismovingRight = false;
            }
            else if (!ismovingRight && col.gameObject.tag == "wall")
            {
                ismovingRight = true;
            }
        }
        //when ball misses peg
        if (isFailWall)
        {
            if (col.gameObject.tag == "ball")
            {
                ScoreKeeper.GameFailed();
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }
        
    }

    public void MoveBall()
    {
        if (ismovingRight)
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }
        else if (!ismovingRight)
        {
            GetComponent<Rigidbody2D>().velocity = -transform.right * speed;
        }
    }
}
