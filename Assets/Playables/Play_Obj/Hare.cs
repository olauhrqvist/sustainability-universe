using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hare : Herbivore_Script
{
    public GameObject inputMesh;
    private int SatisfiedYears;
    public int satisfiedYears { get { return SatisfiedYears; } set { SatisfiedYears = value; } }
    private int HungryYears;
    public int hungryYears { get { return HungryYears; } set { HungryYears = value; } }
    private double FoodNeeded;
    public double foodNeeded { get { return FoodNeeded; } set { FoodNeeded = value; } }
    private int Population;
    public int population { get { return Population; } set { Population = value; } }

    public Hare(int hierarchy = 2,
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
                    double vegetationValue = 0,
                    double foodNeeded = 20,
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
