﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HomeScreenController : MonoBehaviour
{

    Dictionary<string, GameObject> HomeScreenIcons = new Dictionary<string, GameObject>();
    int appIndex = 1;

    // Use this for initialization
    void Start()
    {

        GameObject[] icons = GameObject.FindGameObjectsWithTag("HomeScreenIcon");

        for (int i = 0; i < icons.Length; i++)
        {
            HomeScreenIcons.Add(icons[i].name, icons[i]);
        }

        foreach (KeyValuePair<string, GameObject> icon in HomeScreenIcons)
        {
            icon.Value.transform.position += new Vector3(0, 10, 0);
        }
    }

    public void SetCurrentAppIcon(Sprite newSprite)
    {
        if (appIndex <= HomeScreenIcons.Count)   //temp fix so game doesn't lock up when homescreen fills
        {
            GameObject currentIcon = HomeScreenIcons["HomeScreenAppIcon" + appIndex.ToString()];
            currentIcon.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }

    public void LowerNextIcon()
    {
        if (appIndex <= HomeScreenIcons.Count)   //temp fix so game doesn't lock up when homescreen fills
        {
            GameObject currentIcon = HomeScreenIcons["HomeScreenAppIcon" + appIndex.ToString()];

            Hashtable hashtable = new Hashtable();
            hashtable.Add("y", currentIcon.transform.position.y - 10);
            hashtable.Add("speed", 10);
            hashtable.Add("easetype", iTween.EaseType.linear);
            hashtable.Add("oncompletetarget", gameObject);
            hashtable.Add("oncomplete", "LowerNextIconComplete");

            iTween.MoveTo(currentIcon, hashtable);

            appIndex++;
        }
        else
        {
            LowerNextIconComplete();
        }
    }

    public void LowerNextIconComplete()
    {
        StartCoroutine(startNotificationAnimAfterSeconds());

    }

    IEnumerator startNotificationAnimAfterSeconds()
    {
        yield return new WaitForSeconds(1f);
        GameObject notificationBar = GameObject.Find("notificationBar");
        notificationBar.GetComponent<NotificationbarFade>().startFade();
        notificationController notification = GameObject.Find("Notification").GetComponent<notificationController>();
        notification.TweenNotificationDown();
    }

}
