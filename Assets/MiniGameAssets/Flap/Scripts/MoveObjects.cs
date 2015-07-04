using UnityEngine;
using System.Collections;

public class MoveObjects : MonoBehaviour {
    public float speed;

    void Update()
    {
        if (ScoreKeeper.GameStarted)
        {
            UpdateStartedGame();
        }
    }

    void UpdateStartedGame()
    {
            gameObject.transform.Translate(Time.deltaTime * speed * -1f, 0f, 0f);
    }
}
