using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spruce : Tree_Script
{
    public GameObject inputMesh;

    public Spruce(int hierarchy = 1,
                    int ID = 1,
                    GameObject test = default,
                    int range = 1,
                    int space = 1,
                    Dictionary<string, double> enviroment = null,
                    int forestid = 0,
                    int growthtime = 1,
                    string species = "Spruce",
                    int sunlightcost = 1,
                    int nutritioncost = 1,
                    double meatValue = 0,
                    double vegetationValue = 150//plojvalue
                    ) : base(hierarchy,
                           ID,
                           test,
                           range,
                           space,
                           enviroment,
                           forestid,
                           growthtime,
                           species,
                           sunlightcost,
                           nutritioncost,
                           meatValue,
                           vegetationValue,
                           0)
    {
  
    }
    private void Start()
    {
        SetModel(inputMesh);
    }
}
