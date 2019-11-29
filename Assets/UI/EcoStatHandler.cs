using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoStatHandler : MonoBehaviour
{
    //private Global_Database globalDatabasea;
    private TileClass tileclass;
    static private Color DefaultColor = new Color(0, 102, 0);
    static private Color MarkColor = new Color(0, 0, 1, 100);
    Queue<Action> ActionQueue = new Queue<Action>();    // Used for toggling UI changes
    private string LastAction;
    private Global_Database globalDatabase;// = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().globalDatabase;
    readonly Dictionary<string, dynamic> dict = new Dictionary<string, dynamic>();
    // Color tiles based on ground type
    void Awake()
    {
        // creates a dictionary of animals in the scene
        globalDatabase = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().globalDatabase;

        dict["Wolf"] = globalDatabase.WolfList;
        dict["Shrew"] = globalDatabase.ShrewList;
        dict["Weasel"] = globalDatabase.WeaselList;
        dict["Fox"] = globalDatabase.FoxList;

        dict["Mouse"] = globalDatabase.MouseList;
        dict["Hare"] = globalDatabase.HareList;
        dict["RoeDeer"] = globalDatabase.DeerList;
        dict["Moose"] = globalDatabase.MooseList;

        dict["Squirrel"] = globalDatabase.SquirrelList;
        dict["Rat"] = globalDatabase.RatList;
        dict["Boar"] = globalDatabase.BoarList;
        dict["BrownBear"] = globalDatabase.BrownBearList;

        dict["Beech"] = globalDatabase.BeechList;
        dict["Birch"] = globalDatabase.BirchList;
        dict["Spruce"] = globalDatabase.SpruceList;
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
        if (dict.ContainsKey(Animal))   // Test to see if Key exists
        {
            List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
            if (!active)
            {
                List<string> Marks = new List<string>();
                foreach (var a in dict[Animal]) // add all position to a list
                {
                    Marks.Add(a.TilePosition);
                    MarkMap(Marks);
                }
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
    }

    // Let another function change color of all marked objects
    private void MarkMap(List<string> Marks)
    {
        List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
        string temp = "";
        foreach (var M in Marks)
        {
            foreach (var T in tiles)        // Search for tile
            {
                temp += T.x;
                temp += T.y;
                //Debug.Log(M + " =? " + temp);

                if (M == temp)     // If Tile matches animal location
                {
                    T.tileGameObject.GetComponent<Renderer>().material.color = MarkColor;//material.color = color;
                    temp = "";
                    break;
                }
                temp = "";
            }
        }
    }
}