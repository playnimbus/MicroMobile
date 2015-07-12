using UnityEngine;
using System.Collections;

public class notificationController : MonoBehaviour
{

    Vector3 NotificationDownPosition;
    Vector3 NotificationUpPosition;
    Vector3 NotificationMiniGamePosition;

    Sprite AppIcon;
    TextMesh AppTitle;
    TextMesh NotificationFlavorText;

    bool currentlySlidingUp = false;

    // Use this for initialization
    void Start()
    {

        AppIcon = GameObject.Find("appIconBackground").GetComponent<SpriteRenderer>().sprite;
        AppTitle = GameObject.Find("NotificationGameName").GetComponent<TextMesh>();
        NotificationFlavorText = GameObject.Find("NotificationText").GetComponent<TextMesh>();

        NotificationDownPosition = GameObject.Find("NotificationDownPosition").transform.position;
        NotificationUpPosition = GameObject.Find("NotificationUpPosition").transform.position;
        NotificationMiniGamePosition = GameObject.Find("NotificationMiniGamePosition").transform.position;
    }

    void Update()
    {
        if (currentlySlidingUp)
        {
            if (gameObject.transform.position.y < NotificationMiniGamePosition.y)
            {
                gameObject.transform.localPosition += new Vector3(0, 3.5f * Time.deltaTime, 0);
            }
            else if (gameObject.transform.position.y >= NotificationMiniGamePosition.y)
            {
                gameObject.transform.position = NotificationMiniGamePosition;
                currentlySlidingUp = false;
            }
        }
    }

    public void setNotificationInfo(AppInfoContainer appInfo)
    {
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



    public void onTweenNotificationComplete()
    {
        gameObject.transform.parent = Camera.main.transform;
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
        currentlySlidingUp = false;
        resetSpriteTransparancy();
    }

    public void startNotificationSlideUp()
    {
        currentlySlidingUp = true;
        gameObject.transform.parent = null;
    }

    void fadeOutNotification()
    {
        SpriteRenderer[] renderers = gameObject.GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].color = new Color(renderers[i].color.r, renderers[i].color.g, renderers[i].color.b, renderers[i].color.a - (0.2f * Time.deltaTime));
        }

        TextMesh[] meshes = gameObject.GetComponentsInChildren<TextMesh>();
        for (int i = 0; i < meshes.Length; i++)
        {
            meshes[i].color = new Color(meshes[i].color.r, meshes[i].color.g, meshes[i].color.b, meshes[i].color.a - (0.2f * Time.deltaTime));
        }
    }
    void resetSpriteTransparancy()
    {
        SpriteRenderer[] renderers = gameObject.GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].color = new Color(renderers[i].color.r, renderers[i].color.g, renderers[i].color.b, 1);
        }

        TextMesh[] meshes = gameObject.GetComponentsInChildren<TextMesh>();
        for (int i = 0; i < meshes.Length; i++)
        {
            meshes[i].color = new Color(meshes[i].color.r, meshes[i].color.g, meshes[i].color.b, 1);
        }
    }
}
