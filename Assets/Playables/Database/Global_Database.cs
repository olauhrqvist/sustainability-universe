using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global_Database : MonoBehaviour
{

    public List<TileClass> TileList = new List<TileClass>();

    public Global_Database()
    {
        TileList = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().Getlist();    
    }

    public void Update_DataBase()
    { 

        foreach (TileClass i in TileList)
        {
        Animal_Update(i);
        }

    }

    public void Animal_Update(TileClass Tile)
    {

    }









}
