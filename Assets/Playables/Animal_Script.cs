﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_Script : Base_Playable
{
    int FoodHierarchy;
    int Population;
    double MeatValue; //how much food does the animals contain
    double VegetationValue; //how much food the vegetation contains
    double FoodNeeded; //food needed per population of 1
    public double AvailableFood()
    {
        return 0.0f;
    }
    public int GetFoodHierarchy() { return FoodHierarchy; }
    public int GetPopulation() { return Population; }
    public void SetPopulation(int Input) { Population = Input; }
    protected Animal_Script(
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
                            string species,
                            double meatValue,
                            double vegetationValue,
                            double foodNeeded) : base(
                                                type,
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
                                                foodNeeded)
        {
            FoodHierarchy = hierarchy;
            Population = pop;
        }
}
