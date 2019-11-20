﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birch : Tree_Script
{
    public GameObject inputMesh;

    public Birch(   int hierarchy = 1,
                    int ID = 1,
                    GameObject test = default,
                    int range = 1,
                    int space = 1,
                    Dictionary<string, double> enviroment = null,
                    int forestid = 0,
                    int growthtime = 1,
                    string species = "Birch",
                    int sunlightcost = 1,
                    int nutritioncost = 1
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
                           nutritioncost)
    {

    }
    private void Start()
    {
        SetModel(inputMesh);
    }
}
