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
    private Global_Database globalDatabase;




    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;

        if(!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition)){
            Name = Spawnable.name;
            Type = Spawnable.GetComponent<Base_Playable>().GetBaseType();
            Debug.Log(Name);
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
            AddtoDatabase(sampleObject, type, TargetTile.name);

            tile.GrowObject(sampleObject, type);
        }
    }



    public void AddtoDatabase(string sampleObject, string type, string Tile)
    {
      //globalDatabase = new Global_Database();
      globalDatabase = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().globalDatabase;

        switch (type)
        {
            case "Tree":            
                        globalDatabase.AddTreetype(Tile,sampleObject ,Spawnable);          
                        print("Tile " + name + " and SpruceList count is: " + globalDatabase.TreeTypeList.Count);
                        break;

            case "Carnivore":
                
                         globalDatabase.AddCarnivore(Tile, sampleObject, Spawnable);
                         print("Tile " + name + " and ShrewList count is: " + globalDatabase.CarnivoreList.Count);
                         break;

            case "Herbivore":
                        globalDatabase.AddHerbivore(Tile, sampleObject, Spawnable);
                        print("Tile " + name + " and MouseList count is: " + globalDatabase.HerbivoreList.Count);
                        break;

            case "Omnivore":
                    case "Squirrel":
                        globalDatabase.AddOmnivore(Tile, sampleObject, Spawnable);
                        print("Tile " + name + " and SquirrleList count is: " + globalDatabase.OmnivoreList.Count);
                        break;

                Debug.Log("Type not found : " + type);
                break;

        }













    }
}
