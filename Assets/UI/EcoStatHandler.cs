using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EcoStatHandler : MonoBehaviour
{
    //private Global_Database globalDatabasea;
    private TileClass tileclass;
    static private Color DefaultColor = new Color(0, 102, 0);
    static private Color MarkColor = new Color(0, 0, 1, 100);
    readonly Queue<Action> ActionQueue = new Queue<Action>();    // Used for toggling UI changes
    private string LastAction;
    private Global_Database globalDatabase;// = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().globalDatabase;
    readonly Dictionary<string, dynamic> AnimalTypeDict = new Dictionary<string, dynamic>();
    Dictionary<string, TileClass> TileDict;
    // Color tiles based on ground type
    void Awake()
    {
        // creates a dictionary of animals in the scene
        globalDatabase = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().globalDatabase;
        DefaultColor = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().planeColor;

        AnimalTypeDict["Wolf"] = globalDatabase.WolfList;
        AnimalTypeDict["Shrew"] = globalDatabase.ShrewList;
        AnimalTypeDict["Weasel"] = globalDatabase.WeaselList;
        AnimalTypeDict["Fox"] = globalDatabase.FoxList;

        AnimalTypeDict["Mouse"] = globalDatabase.MouseList;
        AnimalTypeDict["Hare"] = globalDatabase.HareList;
        AnimalTypeDict["RoeDeer"] = globalDatabase.DeerList;
        AnimalTypeDict["Moose"] = globalDatabase.MooseList;

        AnimalTypeDict["Squirrel"] = globalDatabase.SquirrelList;
        AnimalTypeDict["Rat"] = globalDatabase.RatList;
        AnimalTypeDict["Boar"] = globalDatabase.BoarList;
        AnimalTypeDict["BrownBear"] = globalDatabase.BrownBearList;

        AnimalTypeDict["Beech"] = globalDatabase.BeechList;
        AnimalTypeDict["Birch"] = globalDatabase.BirchList;
        AnimalTypeDict["Spruce"] = globalDatabase.SpruceList;

        TileDict = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict; 
    }
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
            if (LastAction == Animal)
            {
                LastAction = "";
                active = true;
            }
        }
        if (AnimalTypeDict.ContainsKey(Animal))   // Test to see if Key exists
        {
            int sum = 0;
            List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
            if (!active)
            {
                List<string> Marks = new List<string>();
                foreach (var a in AnimalTypeDict[Animal]) // add all position to a list
                {
                    Marks.Add(a.TilePosition);
                    if (Animal != "Spruce" && Animal != "Birch" && Animal != "Beech")
                    {
                        sum += a.population;
                    }
                    else
                    {
                        sum++;
                    }
                }
                MarkMap(Marks);
                textbox.SetActive(true);
                text.GetComponent<Text>().text = sum + " " + Animal;

                ActionQueue.Enqueue(() => ClearMap());
                LastAction = Animal;
            }
        }
        else
        {
            Debug.Log("Key Doesn't Exist");
        }
    }
    private void ClearMap()
    {
        List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;

        foreach (var tile in tiles)
        {
            tile.tileGameObject.GetComponent<Renderer>().material.color = DefaultColor;
        }
        textbox.SetActive(false);
    }

    // Let another function change color of all marked objects
    public GameObject textbox;
    public GameObject text;
    private void MarkMap(List<string> Marks)
    {
        foreach (var M in Marks)
        {
            if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(M))
            {
                TileDict[M].tileGameObject.GetComponent<Renderer>().material.color = MarkColor;
            }
        }
        return;
    }
}