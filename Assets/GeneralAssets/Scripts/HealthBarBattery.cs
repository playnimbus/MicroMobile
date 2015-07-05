using UnityEngine;
using System.Collections;

public class HealthBarBattery : MonoBehaviour {

    public Sprite zeroBar;
    public Sprite oneBar;
    public Sprite twoBar;
    public Sprite threeBar;
    public Sprite fourBar;
    public Sprite fiveBar;

    SpriteRenderer mySpriteRenderer;

    void Start()
    {
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void setIcon(int currentHealth){

        switch (currentHealth)
        {
            case 0: mySpriteRenderer.sprite = zeroBar; break;
            case 1: mySpriteRenderer.sprite = oneBar; break;
            case 2: mySpriteRenderer.sprite = twoBar; break;
            case 3: mySpriteRenderer.sprite = threeBar; break;
            case 4: mySpriteRenderer.sprite = fourBar; break;
            case 5: mySpriteRenderer.sprite = fiveBar; break;
        }
    }

}
