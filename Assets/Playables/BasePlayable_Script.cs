﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TileTypes { podzol, dirt }

public abstract class Base_Playable : MonoBehaviour
{
    int ID;
    GameObject Mesh;
    public string Type;
    int Range;
    double OverallHealth = 100;
    int SpaceCost;
    Dictionary<string, double> Enviroments = new Dictionary<string, double>();
    int ForestID;
    int GrowthTime;
    string Species; // species

    protected Base_Playable(
                            string type,
                            int ID,
                            GameObject mesh,
                            int range,
                            int space,
                            Dictionary<string, double> enviroment,
                            int forestid,
                            int growthtime,
                            string species)
        {
            this.ID = ID;
            Mesh = mesh;
            Type = species;
            Range = range;
            SpaceCost = space;
            Enviroments = enviroment;
            ForestID = forestid;
            GrowthTime = growthtime;
        }
    public void setModel(GameObject mesh) 
    {
        Mesh = mesh;
    }
    public GameObject getModel()
    { 
        return Mesh; 
    }

    public string getSpecies()
    {
        return Species;
    }

    public string getType()
    {
        return Type;
    }
    
}
