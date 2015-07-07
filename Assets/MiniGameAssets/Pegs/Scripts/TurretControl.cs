using UnityEngine;
using System.Collections;

public class TurretControl : MonoBehaviour {

    public GameObject pivot;
    public GameObject turretCannon;
    public GameObject ball;

    public int balls = 1;

    public float speed;
    public float minSwipeLength = 5f;

    private int rotRange;

    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;

    private Vector2 firstClickPos;
    private Vector2 secondClickPos;

	void Update () {
        if (ScoreKeeper.GameStarted)
        {
            UpdateStartedGame();
        }
	}

    void UpdateStartedGame()
    {
        MobileControl();

        //temp
        KeyBoardControl();
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

                //not a swipe? FIRE THE CANNON!
                if (currentSwipe.magnitude < minSwipeLength)
                {
                    Shoot();
                    return;
                }

                //totally a swipe
                currentSwipe.Normalize();

                //swipes left
                if (currentSwipe.x < 0 && rotRange <= 1)
                {
                    pivot.transform.Rotate(Vector3.forward, -20);
                    rotRange++;
                }
                //swipes right
                if (currentSwipe.x > 0 && rotRange >= -1)
                {
                    pivot.transform.Rotate(Vector3.forward, 20);
                    rotRange--;
                }
            }
        }
    }
    void KeyBoardControl()
    {
        //shoot when space down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        //aims left
        if (Input.GetKeyDown(KeyCode.A) && rotRange <= 1)
        {
            pivot.transform.Rotate(Vector3.forward, -20);
            rotRange++;
        }
        //aims right
        else if (Input.GetKeyDown(KeyCode.D) && rotRange >= -1)
        {
            pivot.transform.Rotate(Vector3.forward, 20);
            rotRange--;
        }
    }

    public void Shoot()
    {
        if (balls > 0)
        {
            balls--;
            GameObject projectile;
            projectile = Instantiate(ball, turretCannon.transform.position, turretCannon.transform.rotation) as GameObject;
            projectile.transform.rotation = pivot.transform.rotation;
            projectile.GetComponent<Rigidbody2D>().velocity = -projectile.transform.up * speed;
            Destroy(projectile, 5);
        }
        
    }
}
