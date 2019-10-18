﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Script : Vegetation
{
    public Tree_Script(
                                int hierarchy,
                                int ID,
                                Mesh mesh,
                                int range,
                                int space,
                                Dictionary<string, double> enviroment,
                                int forestid,
                                int growthtime,
                                string species,
                                int SunlightCost,
                                int NutritionalCost) : base(
                                                    "Tree",
                                                    hierarchy,
                                                    ID,
                                                    mesh,
                                                    range,
                                                    space,
                                                    enviroment,
                                                    forestid,
                                                    growthtime,
                                                    species,
                                                    SunlightCost,
                                                    NutritionalCost)
    {

    }
}
