using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class DropHandler : MonoBehaviour, IDropHandler
{
    public SpawnObject SpawnScript;
    public GameObject sampleObject;
    public String Name;
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;

        if(!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition)){
            Debug.Log("drop");

            //var newobj = SpawnScript.AddObject(sampleObject);
            sampleObject.name = Name;
            SpawnScript.AddObject(sampleObject);

            //string name = SpawnScript.name;
            //newobj.AddComponent(Type.GetType(name));
            //newobj.tag = tagname;
        }

    }
}
