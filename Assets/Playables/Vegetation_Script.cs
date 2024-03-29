﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vegetation : Base_Playable
{
    int GrowthHierarchy;
    int SunlightCost;
    int NutritionalCost;
    //double MeatValue;
    //double VegetationValue;
    private double VegetationValue;
    public double vegetationValue { get { return VegetationValue; } set { VegetationValue = value; } }

    protected Vegetation(
                           string type,
                           int hierarchy,
                           int ID,
                           GameObject mesh,
                           int range,
                           int space,
                           Dictionary<string, double> enviroment,
                           int forestid,
                           int growthtime,
                           string species,
                           int SunlightCost,
                           int NutritionalCost,

                           double VegetationValue
                           ) : base(
                                               type,
                                               ID,
                                               mesh,
                                               range,
                                               space,
                                               enviroment,
                                               forestid,
                                               growthtime,
                                               species

                                             )
    {
        GrowthHierarchy = hierarchy;
        this.SunlightCost = SunlightCost;
        this.NutritionalCost = NutritionalCost;
        VegetationValue = vegetationValue;
    }
}
