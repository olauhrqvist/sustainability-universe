using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoStatHandler : MonoBehaviour
{
    private Global_Database globalDatabase;
    private TileClass tileclass;
    static private Color DefaultColor = new Color(0, 102, 0);
    static private Color MarkColor = new Color(0, 0, 1, 100);
    Queue<Action> ActionQueue = new Queue<Action>();    // Used for toggling UI changes
    private string LastAction;
    // Color tiles based on ground type
    public void DisplaypH(bool active)
    {
        // Empties queue if it exists
        if (ActionQueue.Count != 0)
        {
            Action action = ActionQueue.Dequeue();
            action();
            if (LastAction == "pH")
            {
                LastAction = "";
                active = true;
            }
        }

        List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
        if (!active)
        {
            foreach (var tile in tiles)
            {
                if (tile.Groundtype == "brownearth")
                {
                    tile.tileGameObject.GetComponent<Renderer>().material.color = DefaultColor;
                }

                else if (tile.Groundtype == "podzol")
                {
                    Color color = Color.yellow;
                    tile.tileGameObject.GetComponent<Renderer>().material.color = color;
                }
            }
            // Add it to the queue so that next EcoStat action will reverse this
            ActionQueue.Enqueue(() => ClearMap());
            LastAction = "pH";
        }
    }

    // Default change tile color. used since function only can take 1 argument
    public void DisplayAnimalLocation(string Animal)
    {
        DisplayAnimalHandler(false, Animal);
    }
    public void DisplayAnimalHandler(bool active, string Animal)
    {
        // Empties queue if it exists
        if (ActionQueue.Count != 0)
        {
            Action action = ActionQueue.Dequeue();
            action();
            if(LastAction == Animal)
            {
                LastAction = "";
                active = true;
            }
        }

        List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
        if (!active)
        {
            globalDatabase = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().globalDatabase;
            string temp = "";
            string animaltype = GameObject.Find(Animal).GetComponent<Base_Playable>().GetBaseType();
            
            switch (animaltype) // Searches different databases depending on type // can be optimized
            {
                case "Carnivore":
                    List<CarnivoreInfo> ElementListCar = globalDatabase.CarnivoreList;
                    foreach (var A in ElementListCar)        // Find all animals that match the string
                    {
                        if (A.name == Animal)
                        {
                            foreach (var T in tiles)        // Search for tile
                            {
                                temp += T.x;
                                temp += T.y;
                                //Debug.Log(A.TilePosition+" =? "+ temp);

                                if (A.TilePosition == temp)     // If Tile matches animal location
                                {
                                    T.tileGameObject.GetComponent<Renderer>().material.color = MarkColor;//material.color = color;
                                }
                                temp = "";
                            }
                        }
                    }
                    break;
                case "Herbivore":
                    List<HerbivoreInfo> ElementListHer = globalDatabase.HerbivoreList;
                    foreach (var A in ElementListHer)        // Find all animals that match the string
                    {
                        if (A.name == Animal)
                        {
                            foreach (var T in tiles)        // Search for tile
                            {
                                temp += T.x;
                                temp += T.y;

                                if (A.TilePosition == temp)     // If Tile matches animal location
                                {
                                    T.tileGameObject.GetComponent<Renderer>().material.color = MarkColor;//material.color = color;
                                }
                                temp = "";
                            }
                        }
                    }
                    break;
                case "Omnivore":
                    List<OmnivoreInfo> ElementListOmn = globalDatabase.OmnivoreList;
                    foreach (var A in ElementListOmn)        // Find all animals that match the string
                    {
                        if (A.name == Animal)
                        {
                            foreach (var T in tiles)        // Search for tile
                            {
                                temp += T.x;
                                temp += T.y;

                                if (A.TilePosition == temp)     // If Tile matches animal location
                                {
                                    T.tileGameObject.GetComponent<Renderer>().material.color = MarkColor;//material.color = color;
                                }
                                temp = "";
                            }
                        }
                    }
                    break;
                case "Tree":
                    List<TreeTypeInfo> ElementListTree = globalDatabase.TreeTypeList;
                    foreach (var A in ElementListTree)        // Find all animals that match the string
                    {
                        if (A.name == Animal)
                        {
                            foreach (var T in tiles)        // Search for tile
                            {
                                temp += T.x;
                                temp += T.y;

                                if (A.TilePosition == temp)     // If Tile matches animal location
                                {
                                    T.tileGameObject.GetComponent<Renderer>().material.color = MarkColor;//material.color = color;
                                }
                                temp = "";
                            }
                        }
                    }
                    break;
                default:
                    Debug.Log("Animal type not found");
                    break;
            }
            ActionQueue.Enqueue(() => ClearMap());
            LastAction = Animal;
        }
    }
    private void ClearMap()
    {
        List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;

        foreach (var tile in tiles)
        {
            tile.tileGameObject.GetComponent<Renderer>().material.color = DefaultColor;
        }
    }
}