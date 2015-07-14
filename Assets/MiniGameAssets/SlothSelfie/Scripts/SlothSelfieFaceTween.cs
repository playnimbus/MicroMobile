using UnityEngine;
using System.Collections;

public class SlothSelfieFaceTween : MonoBehaviour {

	// Use this for initialization
    void OnEnable()
    {
        Hashtable hashtable = new Hashtable();
        hashtable.Add("amount", new Vector3(0, 0, 0.1f));
        hashtable.Add("speed", 14);
        hashtable.Add("easetype", iTween.EaseType.linear);
        hashtable.Add("looptype", "pingPong ");

        iTween.RotateBy(gameObject, hashtable);
	}
}
