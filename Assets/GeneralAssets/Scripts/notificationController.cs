using UnityEngine;
using System.Collections;

public class notificationController : MonoBehaviour {

    Vector3 NotificationDownPosition;
    Vector3 NotificationUpPosition;

    Sprite AppIcon;
    TextMesh AppTitle;
    TextMesh NotificationFlavorText;

	// Use this for initialization
	void Start () {

        AppIcon = GameObject.Find("appIconBackground").GetComponent<SpriteRenderer>().sprite;
        AppTitle = GameObject.Find("NotificationGameName").GetComponent<TextMesh>();
        NotificationFlavorText = GameObject.Find("NotificationText").GetComponent<TextMesh>();

        NotificationDownPosition = GameObject.Find("NotificationDownPosition").transform.position;
        NotificationUpPosition = GameObject.Find("NotificationUpPosition").transform.position;
        
    }

    public void setNotificationInfo(AppInfoContainer appInfo){
       // AppIcon = appInfo.AppIcon;
        GameObject.Find("appIconBackground").GetComponent<SpriteRenderer>().sprite = appInfo.AppIcon;
        AppTitle.text = appInfo.AppName;
        NotificationFlavorText.text = appInfo.AppNotificationFlavorText;
    }

    public void TweenNotificationDown()
    {

        Hashtable hashtable = new Hashtable();
        hashtable.Add("position", NotificationDownPosition);
        hashtable.Add("speed", 7);
        hashtable.Add("easetype", iTween.EaseType.easeOutCubic);
        hashtable.Add("oncomplete", "onTweenNotificationComplete");

        iTween.MoveTo(gameObject, hashtable);
    }
    public void onTweenNotificationComplete(){
        StartCoroutine(startGameScreenCameraPanAfterSeconds());
    }

    IEnumerator startGameScreenCameraPanAfterSeconds()
    {
        yield return new WaitForSeconds(1f);
        Camera.main.GetComponent<CameraTween>().TweenToGameScreen();
    }
    
    public void ResetNotificationPosition()
    {
        gameObject.transform.position = NotificationUpPosition;
    }
}
