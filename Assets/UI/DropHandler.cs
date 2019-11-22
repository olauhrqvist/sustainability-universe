using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class DropHandler : MonoBehaviour, IDropHandler
{
    public GameObject Spawnable;
    string Name, Type;
    private List<TileClass> tiles;

    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;

        if(!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition)){
            Name = Spawnable.name;
            Type = Spawnable.GetComponent<Base_Playable>().GetBaseType();
            //Debug.Log(Name);
            AddObject(Name, Type);
        }

    }
    public void AddObject(string sampleObject, string type)
    {

        transform.rotation = Quaternion.identity;

        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            GameObject TargetTile = hit.collider.gameObject;
            tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
            TileClass tile = tiles.Find(x => x.name == TargetTile.name);
            tile.GrowObject(sampleObject, type);
        }
    }
}
