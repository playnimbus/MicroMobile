using UnityEngine;
using System.Collections;

public class PianoGame : MonoBehaviour {

    public GameObject[] row1, row2, row3, row4, row5, row6, row7, row8;
    public GameObject[] rows;
    float timer;
    public float gameTime;
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
        ScoreKeeper.GameStarted = true;
        rows[0].BroadcastMessage("IsCurrentRow", SendMessageOptions.DontRequireReceiver);
	}
	
	// Update is called once per frame
	void Update () {
      //  if (ScoreKeeper.GameStarted)
        {
            GameStartedUpdate();
        }
	}

    void RandomTile(GameObject[] row) 
    {
        int randomTile = Random.Range(0, 3);
        row[randomTile].gameObject.GetComponent<PianoTile>().isBlackTile = true;
    }

    void GameStartedUpdate()
    {
        timer += Time.deltaTime;
    }
}
