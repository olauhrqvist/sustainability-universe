using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saprovore_Script : Animal_Script
{
    public Saprovore_Script(
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
                            double vegetationValue) : base(
                                                "Saprovore",
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
                                                vegetationValue)
        {

        }
    private void Awake()
    {
        SetBaseType("Saprovore");
    }
}
