using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Script : Vegetation
{
    public Tree_Script(
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
                                double MeatValue,
                                double VegetationValue,
                                double foodNeeded,
                                int satisfiedYears,
                                int hungryYears) : base(
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
                                                    NutritionalCost,
                                                 
                                                    VegetationValue)
    {

    }
    private void Awake()
    {
        SetBaseType("Tree");
    }
}
