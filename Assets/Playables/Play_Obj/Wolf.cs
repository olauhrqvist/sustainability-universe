using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Carnivore_Script
{
    public GameObject inputMesh;

    public Wolf(int hierarchy = 4,
                    int ID = 1,
                    int population = 1,
                    GameObject test = default,
                    int range = 1,
                    int space = 1,
                    Dictionary<string, double> enviroment = null,
                    int forestid = 0,
                    int growthtime = 1,
                    string species = "Wolf",
                    double meatValue = 50,
                    double vegetationValue = 0,
                    double foodNeeded = 800,
                    int satisfiedYears = 0,
                    int hungryYears = 0
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
                           vegetationValue,
                           foodNeeded,
                           satisfiedYears,
                           hungryYears)
    {

    }
    private void Start()
    {
        SetModel(inputMesh);
    }
}