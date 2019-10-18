using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herbivore_Script : Animal_Script
{
    public Herbivore_Script(
                            int hierarchy,
                            int pop,
                            int ID,
                            Mesh mesh,
                            int range,
                            int space,
                            Dictionary<string, double> enviroment,
                            int forestid,
                            int growthtime,
                            string species) : base(
                                                "Herbivore",
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
}
