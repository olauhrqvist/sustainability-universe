using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_Script : Base_Playable
{
    //int Type;
    int FoodHierarchy;
    int Population;
    public double AvailableFood()
    {
        return 0.0f;
    }

    public Animal_Script(
                            string type,
                            int hierarchy,
                            int pop,
                            int ID,
                            GameObject mesh,
                            int range,
                            int space,
                            Dictionary<string, double> enviroment,
                            int forestid,
                            int growthtime,
                            string species) : base(
                                                type,
                                                ID,
                                                mesh,
                                                range,
                                                space,
                                                enviroment,
                                                forestid,
                                                growthtime,
                                                species)
        {
            FoodHierarchy = hierarchy;
            Population = pop;
        }
}
