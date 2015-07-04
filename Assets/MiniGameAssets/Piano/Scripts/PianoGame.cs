using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PianoGame : MonoBehaviour {

    public GameObject[] row1, row2, row3, row4, row5, row6, row7, row8, row9, row10;
    public GameObject[] rows;
    float timer;
    int currentRow;
    public float winTime;
    public int winRows;
    int rowsLeft;
    public GameObject PianoUIText;
	// Use this for initialization
	void Start () {
        RandomTile(row1);
        RandomTile(row2);
        RandomTile(row3);
        RandomTile(row4);
        RandomTile(row5);
        RandomTile(row6);
        RandomTile(row7);
        RandomTile(row8);
        currentRow = 0;
        rows[currentRow].BroadcastMessage("IsCurrentRow", SendMessageOptions.DontRequireReceiver);
        rowsLeft = winRows;

        PianoUIText.GetComponent<Text>().text = "TAP " + rowsLeft;

        //ScoreKeeper.GameStarted = true; //Uncomment to debug in private scene.
	}
	
	// Update is called once per frame
	void Update () {
        if (ScoreKeeper.GameStarted)
        {
            GameStartedUpdate();
            if (Input.GetKeyDown(KeyCode.R))
            {
                SetNewRow();
            }
        }
	}

    void RandomTile(GameObject[] row) 
    {
        int randomTile = Random.Range(0, 3);
        row[randomTile].gameObject.GetComponent<PianoTile>().isBlackTile = true;
    }

    public void SetNewRow()
    {
        Destroy(rows[currentRow]);
        rowsLeft -= 1;
        PianoUIText.GetComponent<Text>().text = "TAP " + rowsLeft;
        currentRow += 1;
        rows[currentRow].BroadcastMessage("IsCurrentRow", SendMessageOptions.DontRequireReceiver);
        foreach (GameObject row in rows)
        {
            if (row.gameObject != null)
            row.gameObject.transform.Translate(0f, -3f, 0f);
        }
    }

    void GameStartedUpdate()
    {
        
        timer += Time.deltaTime;
        PianoUIText.SetActive(true);
        if (rowsLeft == 0)
        {
            PianoUIText.SetActive(false);
            ScoreKeeper.GameWon();
        }
        if (timer >= winTime && rowsLeft != 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        PianoUIText.SetActive(false);
        ScoreKeeper.GameFailed();
    }
}
