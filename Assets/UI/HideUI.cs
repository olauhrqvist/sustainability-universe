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
    public void ToggleUIElements()
    {
        if (!Hidden)
        {
            Hidden = true;
            foreach (GameObject i in UIElements)
            {
                i.SetActive(false);
            }
            Vector3 temp = new Vector3(Movement, 0, 0);
            foreach (GameObject j in Buttons)
            {
                j.transform.localPosition += temp;
            }

            ButtonSprite.image.sprite = HideSprite;
        }
        else
        {
            Hidden = false;
            UIElements[0].SetActive(true);
            Vector3 temp = new Vector3(-Movement, 0, 0);

            foreach (GameObject j in Buttons)
            {
                j.transform.localPosition += temp;
            }

            ButtonSprite.image.sprite = ShowSprite;
        }
    }
}