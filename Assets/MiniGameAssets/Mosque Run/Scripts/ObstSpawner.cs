using UnityEngine;
using System.Collections;

public class ObstSpawner : MonoBehaviour {

    public GameObject[] spawner;
    public GameObject obst;

    public float timeUntil = 1.1f;

    private float timer;

    void Update()
    {
        if (ScoreKeeper.GameStarted)
        {
            timer += Time.deltaTime;
            if (timer > timeUntil)
            {
                SpawnObst();
                timer =  0;
            }
        }
    }

    public void SpawnObst()
    {
        GameObject selectSpawn;
        selectSpawn = spawner[Random.Range(0, spawner.Length)];
        Instantiate(obst, selectSpawn.transform.position, selectSpawn.transform.rotation);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Fail")
        {
            Destroy(col.gameObject);
        }
    }
}
