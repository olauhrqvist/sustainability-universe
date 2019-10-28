﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fungi_Script : Vegetation
{
    public Fungi_Script(
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
                                                    "Fungi",
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