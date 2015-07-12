using UnityEngine;
using System.Collections;

public class TurretControl : MonoBehaviour {

    public GameObject mousePos;

    public GameObject pivot;
    public GameObject turretCannon;
    public GameObject ball;

    public int balls = 1;
    public float timeuntilLoss;
    
    public float speed;
    public float minSwipeLength = 5f;
    
    private Vector3 v_diff;
    private float atan2;
    private float lossTimer;

	void Update () {
        if (ScoreKeeper.GameStarted)
        {
            UpdateStartedGame();
        }
	}

    void UpdateStartedGame()
    {
        mousePos.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        MobileControl();
        LossTimer();
        //temp
        KeyBoardControl();
    }
    void MobileControl()
    {
        mousePos = GameObject.Find("mousePos");
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Moved)
            {

                v_diff = (mousePos.transform.position - transform.position);
                atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
                float angle = Mathf.Atan2(v_diff.y, v_diff.x) * Mathf.Rad2Deg;
                pivot.transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg);
                pivot.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            }

            if (t.phase == TouchPhase.Ended)
            {
                Shoot();
            }
        }
    }
    void KeyBoardControl()
    {
        //track mouseposition
        if (Input.GetMouseButton(0))
        {
            v_diff = (mousePos.transform.position - transform.position);
            atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
            float angle = Mathf.Atan2(v_diff.y, v_diff.x) * Mathf.Rad2Deg;
            pivot.transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg);
            pivot.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        }

        //shoot when mouse no longer tracked
        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }
    }

    void LossTimer()
    {
        if (!GameObject.Find("ball"))
        {
            lossTimer += Time.deltaTime;
            if (lossTimer > timeuntilLoss)
            {
                ScoreKeeper.GameFailed();
            }
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
        }
        
    }
}
