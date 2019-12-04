using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationScript : MonoBehaviour
{
    public GameObject prefab;
    public void AddToStack()
    {
        var parent = GameObject.Find("NotificationsContent");
        GameObject createImage = Instantiate(prefab) as GameObject;
        createImage.transform.SetParent(parent.transform, false);
        createImage.transform.SetAsFirstSibling();
        createImage.GetComponentInChildren<Text>().text = "aye lemonlemonlemonlemonlemonlemonlemon";
    }

}
