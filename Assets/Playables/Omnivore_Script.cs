using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Omnivore_Script : Animal_Script
{
    public Omnivore_Script(
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
                                                species)
        {

        }
}
