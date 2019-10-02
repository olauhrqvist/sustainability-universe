using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineHover : MonoBehaviour
{
    public Color startColor;
    public Color mouseOverColor;
    bool mouseOVer = false;

    void OnMouseOver()
    {
        mouseOVer = true;
        GetComponent<Renderer>().material.SetColor("_Color", mouseOverColor);
        //If your mouse hovers over the GameObject with the script attached, output this message
        //Debug.Log("Mouse is over GameObject.");

      
    }

    void OnMouseExit()
    {
        mouseOVer = false;
       GetComponent<Renderer>().material.SetColor("_Color", startColor);
        //The mouse is no longer hovering over the GameObject so output this message each frame
       // Debug.Log("Mouse is no longer on GameObject.");
    }
}