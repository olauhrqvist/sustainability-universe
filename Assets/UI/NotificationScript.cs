using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationScript : MonoBehaviour
{
    public GameObject prefab;
    public GameObject parent;
    public GameObject button;
    public GameObject panel;

    bool newmessage = false;
    public void AddToStack(string input, int urgency)
    {
        Color color = Color.cyan;
        switch (urgency)
        {
            case 1:
                color = Color.red;
                break;
            case 2:
                color = Color.yellow;
                break;
            case 3:
                color = Color.green;
                break;
            default:
                break;
        }

        GameObject createImage = Instantiate(prefab) as GameObject;
        createImage.transform.SetParent(parent.transform, false);
        createImage.transform.SetAsFirstSibling();
        createImage.GetComponentInChildren<Text>().text = input;
        color.a = 0.75f;
        createImage.GetComponent<Image>().color = color;
        if (!panel.activeInHierarchy)
        {
            Debug.Log("ayo what");
            newmessage = true;
        }
        UpdateNotification();
    }
    public void UpdateNotification()
    {
        if (newmessage)
            button.SetActive(true);
        else
            button.SetActive(false);
        newmessage = false;
    }
    public void Extinct(string type)
    {
        AddToStack(type + " has gone extinct!", 1);
    }
    public void GoingExtinct(string type)
    {
        AddToStack(type + " is almost extinct!", 2);
    }
    public void SeedUnlocked(string type)
    {
        AddToStack(type + " has been unlocked in the shop", 3);
    }
    public void TimePassed(int year)
    {
        if(year%10 == 0)
        {
            AddToStack("a decade" + " has passed", 4);

        }
        else
        {
            AddToStack(year + " has passed", 4);
        }
    }
}
