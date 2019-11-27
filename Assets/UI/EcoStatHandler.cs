using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoStatHandler : MonoBehaviour
{
    private Global_Database globalDatabase;
    private TileClass tileclass;
    private bool TogglepH = false;
    private List<Action> ActionList = new List<Action>();
    static private Color DefaultColor = new Color(0, 102, 0);
    public void DisplaypH(bool active)
    {
        /*if (ActionList != null)
        {
            ActionList[0].DynamicInvoke();
        }*/
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
            //ActionList.Add(delegate { DisplaypH(true); }) ;
        }
        else
        {
            foreach (var tile in tiles)
            {
                tile.tileGameObject.GetComponent<Renderer>().material.color = DefaultColor;
            }
            //ActionList.Add(delegate { DisplaypH(false); });
        }
    }
}
//GameObject.Find("wolf").GetComponent<Wolf>().GetFoodHierarchy();
//GameObject.Find(name).GetComponent<Wolf>().GetFoodHierarchy();

