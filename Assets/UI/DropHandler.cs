using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public GameObject Spawnable;
    string Name, Type;
    private List<TileClass> tiles;
    private Global_Database globalDatabase;
    private RewardSystem rewardsystem;
    private GameObject text;

    public void Start()
    {
        rewardsystem = GameObject.Find("EventSystem").GetComponent<YearCounter>().other;
        text = GameObject.Find("EventSystem").GetComponent<YearCounter>().text;
    }

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
                        if (rewardsystem.currency < 10)
                        {
                            Debug.Log("Unsufficient funds!"); //change to break when ready
                            break;
                        }
                        rewardsystem.currency -= 10f;
                        globalDatabase.AddSpruce(name, Spawnable);
                        //print("Tile " + name + " and SpruceList count is: " + globalDatabase.SpruceList.Count);
                        break;

                    case "Birch":
                        if (rewardsystem.currency < 15)
                        {
                            Debug.Log("Unsufficient funds!"); //change to break when ready
                            break;
                        }
                        rewardsystem.currency -= 15f;
                        globalDatabase.AddBirch(name, Spawnable);
                        //print("Tile " + name + " and BirchList count is: " + globalDatabase.BirchList.Count);
                        break;

                    case "Beech":
                        if (rewardsystem.currency < 20)
                        {
                            Debug.Log("Unsufficient funds!"); //change to break when ready
                            break;
                        }
                        rewardsystem.currency -= 20f;
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
                        if (rewardsystem.currency < 10)
                        {
                            Debug.Log("Unsufficient funds!"); //change to break when ready
                            break;
                        }
                        rewardsystem.currency -= 10f;
                        globalDatabase.AddShrew(name, Spawnable);
                        print("Tile " + name + " and ShrewList count is: " + globalDatabase.ShrewList.Count);
                        break;

                    case "Weasel":
                        if (rewardsystem.currency < 20)
                        {
                            Debug.Log("Unsufficient funds!"); //change to break when ready
                            break;
                        }
                        rewardsystem.currency -= 20f;
                        globalDatabase.AddWeasel(name, Spawnable);
                        print("Tile " + name + " and WeaselList count is: " + globalDatabase.WeaselList.Count);
                        break;

                    case "Fox":
                        if (rewardsystem.currency < 40)
                        {
                            Debug.Log("Unsufficient funds!"); //change to break when ready
                            break;
                        }
                        rewardsystem.currency -= 40f;
                        globalDatabase.AddFox(name, Spawnable);
                        print("Tile " + name + " and FoxList count is: " + globalDatabase.FoxList.Count);
                        break;

                    case "Wolf":
                        if (rewardsystem.currency < 80)
                        {
                            Debug.Log("Unsufficient funds!"); //change to break when ready
                            break;
                        }
                        rewardsystem.currency -= 80f;
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
                        if (rewardsystem.currency < 10)
                        {
                            Debug.Log("Unsufficient funds!"); //change to break when ready
                            break;
                        }
                        rewardsystem.currency -= 10f;
                        globalDatabase.AddMouse(name, Spawnable);
                        print("Tile " + name + " and MouseList count is: " + globalDatabase.MouseList.Count);
                        break;

                    case "Hare":
                        if (rewardsystem.currency < 20)
                        {
                            Debug.Log("Unsufficient funds!"); //change to break when ready
                            break;
                        }
                        rewardsystem.currency -= 20f;
                        globalDatabase.AddHare(name, Spawnable);
                        print("Tile " + name + " and HareList count is: " + globalDatabase.HareList.Count);
                        break;

                    case "RoeDeer":
                        if (rewardsystem.currency < 40)
                        {
                            Debug.Log("Unsufficient funds!"); //change to break when ready
                            break;
                        }
                        rewardsystem.currency -= 40f;
                        globalDatabase.AddDeer(name, Spawnable);
                        print("Tile " + name + " and DeerList count is: " + globalDatabase.DeerList.Count);
                        break;

                    case "Moose":
                        if (rewardsystem.currency < 80)
                        {
                            Debug.Log("Unsufficient funds!"); //change to break when ready
                            break;
                        }
                        rewardsystem.currency -= 80f;
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
                        if (rewardsystem.currency < 10)
                        {
                            Debug.Log("Unsufficient funds!"); //change to break when ready
                            break;
                        }
                        rewardsystem.currency -= 10f;
                        globalDatabase.AddSquirrel(name, Spawnable);
                        print("Tile " + name + " and SquirrleList count is: " + globalDatabase.SquirrelList.Count);
                        break;

                    case "Rat":
                        if (rewardsystem.currency < 15)
                        {
                            Debug.Log("Unsufficient funds!"); //change to break when ready
                            break;
                        }
                        rewardsystem.currency -= 15f;
                        globalDatabase.AddRat(name, Spawnable);
                        print("Tile " + name + " and RatList count is: " + globalDatabase.RatList.Count);
                        break;

                    case "Boar":
                        if (rewardsystem.currency < 40)
                        {
                            Debug.Log("Unsufficient funds!"); //change to break when ready
                            break;
                        }
                        rewardsystem.currency -= 40f;
                        globalDatabase.AddBoar(name, Spawnable);
                        print("Tile " + name + " and BoarList count is: " + globalDatabase.BoarList.Count);
                        break;

                    case "BrownBear":
                        if (rewardsystem.currency < 95)
                        {
                            Debug.Log("Unsufficient funds!"); //change to break when ready
                            break;
                        }
                        rewardsystem.currency -= 95f;
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
        text.GetComponent<Text>().text = rewardsystem.currency + " KR";
    }
}
