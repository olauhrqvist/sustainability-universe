using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Omnivore_Script : Animal_Script
{
    public Omnivore_Script(
                            int hierarchy,
                            int pop,
                            int ID,
                            GameObject mesh,
                            int range,
                            int space,
                            Dictionary<string, double> enviroment,
                            int forestid,
                            int growthtime,
                            string species,
                            double meatValue,
                            double vegetationValue,
                            double foodNeeded,
                            int satisfiedYears,
                            int hungryYears) : base(
                                                "Omnivore",
                                                hierarchy,
                                                pop,
                                                ID,
                                                mesh,
                                                range,
                                                space,
                                                enviroment,
                                                forestid,
                                                growthtime,
                                                species,
                                                meatValue,
                                                vegetationValue,
                                                foodNeeded,
                                                satisfiedYears,
                                                hungryYears)
        {

        }
    private void Awake()
    {
        SetBaseType("Omnivore");
    }
}
