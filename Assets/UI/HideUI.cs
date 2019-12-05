using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideUI : MonoBehaviour
{
    public GameObject[] UIElements;
    public GameObject[] Buttons;
    bool Hidden = false;
    public int Movement;
    public Sprite ShowSprite;
    public Sprite HideSprite;
    public Button ButtonSprite;
    public GameObject Hide;
    public GameObject Show;
    public void ToggleText()
    {
        if (!Hidden)
        {
            Hidden = true;
            ToggleAll();
            Hide.SetActive(false);
            Show.SetActive(true);
        }
        else
        {
            Hidden = false;
            ToggleAll();
            Hide.SetActive(true);
            Show.SetActive(false);
        }
    }
    public void ToggleTextNotification()
    {
        if (Hidden)
        {
            Hidden = false;
            Hide.SetActive(true);
            Show.SetActive(false);

            Vector3 temp = new Vector3(-Movement, 0, 0);

            foreach (GameObject j in Buttons)
            {
                j.transform.localPosition += temp;
            }
            UIElements[UIElements.Length - 1].SetActive(true);
        }
        if (!Hidden)
        {
            foreach (GameObject i in UIElements)
            {
                i.SetActive(false);
            }
            UIElements[UIElements.Length - 1].SetActive(true);

        }
    }

        public void ToggleUIElements()
    {
        if (!Hidden)
        {
            Hidden = true;
            ToggleAll();
            ButtonSprite.image.sprite = HideSprite;
        }
        else
        {
            Hidden = false;
            ToggleAll();
            ButtonSprite.image.sprite = ShowSprite;
        }
    }

    private void ToggleAll()
    {
        if (Hidden)
        {
            foreach (GameObject i in UIElements)
            {
                i.SetActive(!Hidden);
            }
            Vector3 temp = new Vector3(Movement, 0, 0);
            foreach (GameObject j in Buttons)
            {
                j.transform.localPosition += temp;
            }
        }
        else
        {
            Vector3 temp = new Vector3(-Movement, 0, 0);
            UIElements[0].SetActive(true);
            foreach (GameObject j in Buttons)
            {
                j.transform.localPosition += temp;
            }
        }
    }
}