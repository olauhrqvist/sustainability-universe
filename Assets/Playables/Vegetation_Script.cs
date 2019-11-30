using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vegetation : Base_Playable
{
    int GrowthHierarchy;
    int SunlightCost;
    int NutritionalCost;
    //double MeatValue;
    //double VegetationValue;

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
                           double MeatValue,
                           double VegetationValue,
                           double foodNeeded,
                           int satisfiedYears,
                            int hungryYears) : base(
                                               type,
                                               ID,
                                               mesh,
                                               range,
                                               space,
                                               enviroment,
                                               forestid,
                                               growthtime,
                                               species,
                                               MeatValue,
                                               VegetationValue,
                                               0,/*default*/
                                               satisfiedYears,
                                               hungryYears)
    {
        GrowthHierarchy = hierarchy;
        this.SunlightCost = SunlightCost;
        this.NutritionalCost = NutritionalCost;
    }
}
