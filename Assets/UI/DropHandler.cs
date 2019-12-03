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

        if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
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

        if (Physics.Raycast(ray, out hit, 200f, LayerMask.GetMask("MapGround")))
        {
            GameObject TargetTile = hit.collider.gameObject;
            tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
            TileClass tile = tiles.Find(x => x.name == TargetTile.name);
            AddtoDatabase(sampleObject, type, TargetTile.name);

            tile.GrowObject(sampleObject, type);
        }
    }



    public void AddtoDatabase(string sampleObject, string type, string name)
    {
        //globalDatabase = new Global_Database();
        globalDatabase = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().globalDatabase;

        switch (type)
        {
            case "Tree":
                switch (sampleObject)
                {
                    case "Spruce":
                        globalDatabase.AddSpruce(name, Spawnable);
                        //print("Tile " + name + " and SpruceList count is: " + globalDatabase.SpruceList.Count);
                        break;

                    case "Birch":
                        globalDatabase.AddBirch(name, Spawnable);
                        //print("Tile " + name + " and BirchList count is: " + globalDatabase.BirchList.Count);
                        break;

                    case "Beech":
                        globalDatabase.AddBeech(name, Spawnable);
                        //print("Tile " + name + " and BeechList count is: " + globalDatabase.BeechList.Count);
                        break;

                    default:
                        //Debug.Log("Tree not found : " + SpawnType);
                        break;
                }
                break;

            case "Carnivore":
                switch (sampleObject)
                {
                    case "Shrew":
                        globalDatabase.AddShrew(name, Spawnable);
                        print("Tile " + name + " and ShrewList count is: " + globalDatabase.ShrewList.Count);
                        break;

                    case "Weasel":
                        globalDatabase.AddWeasel(name, Spawnable);
                        print("Tile " + name + " and WeaselList count is: " + globalDatabase.WeaselList.Count);
                        break;

                    case "Fox":
                        globalDatabase.AddFox(name, Spawnable);
                        print("Tile " + name + " and FoxList count is: " + globalDatabase.FoxList.Count);
                        break;

                    case "Wolf":
                        globalDatabase.AddWolf(name, Spawnable);
                        print("Tile " + name + " and WolfList count is: " + globalDatabase.WolfList.Count);
                        break;

                    default:
                        //  Debug.Log("Carnivore not found : " + SpawnType);
                        break;
                }
                break;

            case "Herbivore":
                switch (sampleObject)
                {
                    case "Mouse":
                        globalDatabase.AddMouse(name, Spawnable);
                        print("Tile " + name + " and MouseList count is: " + globalDatabase.MouseList.Count);
                        break;

                    case "Hare":
                        globalDatabase.AddHare(name, Spawnable);
                        print("Tile " + name + " and HareList count is: " + globalDatabase.HareList.Count);
                        break;

                    case "RoeDeer":
                        globalDatabase.AddDeer(name, Spawnable);
                        print("Tile " + name + " and DeerList count is: " + globalDatabase.DeerList.Count);
                        break;

                    case "Moose":
                        globalDatabase.AddMoose(name, Spawnable);
                        print("Tile " + name + " and MooseList count is: " + globalDatabase.MooseList.Count);
                        break;

                    default:
                        //   Debug.Log("Herbivore not found : " + SpawnType);
                        break;
                }
                break;

            case "Omnivore":
                switch (sampleObject)
                {
                    case "Squirrel":
                        globalDatabase.AddSquirrel(name, Spawnable);
                        print("Tile " + name + " and SquirrleList count is: " + globalDatabase.SquirrelList.Count);
                        break;

                    case "Rat":
                        globalDatabase.AddRat(name, Spawnable);
                        print("Tile " + name + " and RatList count is: " + globalDatabase.RatList.Count);
                        break;

                    case "Boar":
                        globalDatabase.AddBoar(name, Spawnable);
                        print("Tile " + name + " and BoarList count is: " + globalDatabase.BoarList.Count);
                        break;

                    case "BrownBear":
                        globalDatabase.AddBear(name, Spawnable);
                        print("Tile " + name + " and BrownBearList count is: " + globalDatabase.BrownBearList.Count);
                        break;

                    default:
                        //  Debug.Log("Omnivore not found : " + SpawnType);
                        break;
                }
                break;

            default:
                Debug.Log("Type not found : " + type);
                break;

        }
    }
}
