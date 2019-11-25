using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carnivore_Script : Animal_Script
{
    //species hierarchy pop id mesh range space enviroment forestid growthtime
    public Carnivore_Script(
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
                                                "Carnivore",
                                                hierarchy,
                                                pop,
                                                ID,
                                                mesh,
                                                range,
                                                space,
                                                enviroment,
                                                forestid,
                                                growthtime,
                                                species)
        {

        }
    private void Awake()
    {
        SetBaseType("Carnivore");
    }
}
