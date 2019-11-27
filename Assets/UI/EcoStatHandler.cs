using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoStatHandler : MonoBehaviour
{
    private Global_Database globalDatabase;
    private TileClass tileclass;
    static private Color DefaultColor = new Color(0, 102, 0);
    Queue<Action> ActionQueue = new Queue<Action>();    // Used for toggling UI changes

    // Color tiles based on ground type
    public void DisplaypH(bool active)
    {
        // Empties queue if it exists
        if (ActionQueue.Count != 0)
        {
            Action action = ActionQueue.Dequeue();
            action();
        }
        else
        {
            List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
            if (!active)
            {
                foreach (var tile in tiles)
                {


                    if (tile.Groundtype == "brownearth")
                    {
                        Color color = new Color(51, 102, 0);
                        tile.tileGameObject.GetComponent<Renderer>().material.color = color;
                    }

                    else if (tile.Groundtype == "podzol")
                    {
                        Color color = new Color(0, 102, 0);
                        tile.tileGameObject.GetComponent<Renderer>().material.color = color;
                    }
                }
                // Add it to the queue so that next EcoStat action will reverse this
                ActionQueue.Enqueue(() => DisplaypH(true));
            }
            else
            {
                // Reverse the coloring
                foreach (var tile in tiles)
                {
                    tile.tileGameObject.GetComponent<Renderer>().material.color = DefaultColor;
                }
            }
        }
    }
    public void DisplayAnimalLocation(string Animal)
    {
        return;
    }
}
