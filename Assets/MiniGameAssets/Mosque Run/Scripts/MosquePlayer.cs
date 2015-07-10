using UnityEngine;
using System.Collections;

public class MosquePlayer : MonoBehaviour {

    public float timeuntilWin;
    private int movRange;

    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;

    private Vector2 firstClickPos;
    private Vector2 secondClickPos;

    private GameObject[] obsts;

	void Update () {
        if (ScoreKeeper.GameStarted)
        {
            WinTimer();
            MobileControl();
            KeyBoardControl();
        }
	}
    void MobileControl()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }

            if (t.phase == TouchPhase.Ended)
            {
                secondPressPos = new Vector2(t.position.x, t.position.y);
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
                currentSwipe.Normalize();

                //strafe left
                if (currentSwipe.x < 0 && movRange > -1)
                {
                    transform.position += new Vector3(-1, 0, 0);
                    movRange--;
                }
                //strafe right
                if (currentSwipe.x > 0 && movRange < 1)
                {
                    transform.position += new Vector3(1, 0, 0);
                    movRange++;
                }
            }
        }
    }

    void KeyBoardControl()
    {
        //strafe left
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
            movRange--;
        }

        //strafe right
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);
            movRange++;
        }
    }

    void WinTimer()
    {
        timeuntilWin -= Time.deltaTime;
        if (timeuntilWin <= 0)
        {
            obsts = GameObject.FindGameObjectsWithTag("Fail");
            for (int i = 0; i < obsts.Length; i++)
            {
                Destroy(obsts[i]);
            }
            ScoreKeeper.GameWon();

            
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Fail")
        {
            obsts = GameObject.FindGameObjectsWithTag("Fail");
            for (int i = 0; i < obsts.Length; i++)
            {
                Destroy(obsts[i]);
            }
            ScoreKeeper.GameFailed();
        }
    }
}
