using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hare : Herbivore_Script
{
    public GameObject inputMesh;

    public Hare(int hierarchy = 1,
                    int ID = 1,
                    int population = 1,
                    GameObject test = default,
                    int range = 1,
                    int space = 1,
                    Dictionary<string, double> enviroment = null,
                    int forestid = 0,
                    int growthtime = 1,
                    string species = "Hare",
                    double meatValue = 3,
                    double vegetationValue = 0
                    ) : base(hierarchy,
                           population,
                           ID,
                           test,
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
    private void Start()
    {
        SetModel(inputMesh);
    }
}
