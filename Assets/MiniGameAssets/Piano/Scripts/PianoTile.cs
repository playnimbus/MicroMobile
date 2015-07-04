using UnityEngine;
using System.Collections;

public class PianoTile : MonoBehaviour {
    public bool isBlackTile;
    public bool isCurrentRow;
    public float speed;
    GameObject gameLogic;
	// Use this for initialization
	void Start () {

	}
    void IsCurrentRow()
    {
        isCurrentRow = true;
    }
	
	// Update is called once per frame
    void Update()
    {
        if (gameLogic == null)
            gameLogic = GameObject.Find("PianoLogic");

        if (isBlackTile)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }

        if (ScoreKeeper.GameStarted)
        {
            GameStartedUpdate();
        }
    }

    void GameStartedUpdate()
    {
        
    }

    void OnMouseDown()
    {
        if (ScoreKeeper.GameStarted && isBlackTile && isCurrentRow)
        {
            Debug.Log("Win");
            gameLogic.GetComponent<PianoGame>().SetNewRow();
        }
        if (ScoreKeeper.GameStarted && !isBlackTile && isCurrentRow)
        {
            Debug.Log("fail");
            gameLogic.GetComponent<PianoGame>().GameOver();
        }
    }
    


}
