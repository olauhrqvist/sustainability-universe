using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_Script : Base_Playable
{
    int FoodHierarchy;
    //int Population;
    // Already exists in base class
    //how much food does the animals contain
    //public double vegetationValue; //how much food the vegetation contains
    //double FoodNeeded; //food needed per population of 1

    private int SatisfiedYears;
    public int satisfiedYears { get { return SatisfiedYears; } set { SatisfiedYears = value; } }
    private int HungryYears;
    public int hungryYears { get { return HungryYears; } set { HungryYears = value; } }
    private double FoodNeeded;
    public double foodNeeded { get { return FoodNeeded; } set { FoodNeeded = value; } }
    private int Population;
    public int population { get { return Population; } set { Population = value; } }

    private double MeatValue;
    public double meatValue { get { return MeatValue; } set { MeatValue = value; } }

    public double AvailableFood()
    {
        return 0.0f;
    }
    public int GetFoodHierarchy() { return FoodHierarchy; }
  /*  public int GetPopulation() { return Population; }
    public void SetPopulation(int Input) { Population = Input; } */
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
                            double foodNeeded,
                            int satisfiedYears,
                            int hungryYears) : base(
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
            SatisfiedYears = satisfiedYears;
            HungryYears = hungryYears;
            FoodNeeded = foodNeeded;
            MeatValue = meatValue;
            //VegetationValue = vegetationValue;
        }
}
