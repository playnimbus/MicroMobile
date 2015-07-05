using UnityEngine;
using System.Collections;

public class NotificationbarFade : MonoBehaviour {


    SpriteRenderer mySpriteRenderer;
    Color starColor;
    float fade;

    bool isFading = false;


	// Use this for initialization
	void Start () {
        fade = 0;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        starColor = mySpriteRenderer.color;
        mySpriteRenderer.color = new Color(starColor.r, starColor.g, starColor.b, 0);
	}
	
	// Update is called once per frame
	void Update () {

        if (isFading)
        {
            fade += 1.5f * Time.deltaTime;
            mySpriteRenderer.color = new Color(starColor.r, starColor.g, starColor.b, fade);
        }
	}

    public void startFade()
    {
        resetFade();
        isFading = true;
    }

    public void resetFade()
    {
        fade = 0;
        isFading = false;
        mySpriteRenderer.color = new Color(starColor.r, starColor.g, starColor.b, 0);
    }
}
