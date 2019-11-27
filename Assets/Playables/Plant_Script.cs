using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Script : Vegetation
{
    public Plant_Script(
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
                                                    "Plant",
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
                                                    MeatValue,
                                                    VegetationValue,
                                                    0,
                                                    satisfiedYears,
                                                    hungryYears)
    {

    }
    private void Awake()
    {
        SetBaseType("Plant");
    }
}
