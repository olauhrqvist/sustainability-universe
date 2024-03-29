﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BalanceWorld : MonoBehaviour
{

    List<TileClass> globalTiles = new List<TileClass>();
    public static TileClass tile { get; set; }
    private Global_Database Databas;
    public int Happiness; //the variable that sets the reward each year. Gets incremented by 2 if the animals can reproduce and by 1 if they are satisfied.
    public NotificationScript ns;

    public BalanceWorld()  {}


    // Update is called once per year, this is where all the animals are getting updated
    public void YearUpdate()
    {
        Happiness = 0;
        Databas = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().globalDatabase;
        globalTiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().Getlist();


        /*
        The food intake is based on the animal type and then their internal hierarchical order. In order for the carnivores to 
        survive they have to eat meat. To get meat for the carnivores on the tile we'll need to have vegetation and then 
        herbivores or omnivores on the tile. Due to lack of time we didn't lessen the population of the animal a carnivore
        ate.
        */


        //start with herbivores
        //extra comment in Databas.Mouselist loop
        for (int i = 0; i < Databas.MouseList.Count; i++)
        {
            MouseInfo m = Databas.MouseList[i];
            if (!update_mouse(m, 0.4, 0.35)) //Takes the animal info, birthrate and starvingrate. Returns a bool.
            {
                Databas.MouseList.RemoveAt(i); //if the method returned false, then the animal population was 0 and the object is removed from the list.
                if (Databas.MouseList.Count == 0)
                    ns.Extinct("Mouse"); //Sends a notification that the animal has gone extinct from the map.
            }
        }
        for (int i = 0; i < Databas.HareList.Count; i++)
        {
            HareInfo h = Databas.HareList[i];
            if (!update_hare(h, 0.27, 0.22))
            {
                Databas.HareList.RemoveAt(i);
                if (Databas.HareList.Count == 0)
                    ns.Extinct("Hare");
            }
        }
        for (int i = 0; i < Databas.DeerList.Count; i++)
        {
            DeerInfo d = Databas.DeerList[i];
            if (!update_deer(d, 0.20, 0.15))
            {
                Databas.DeerList.RemoveAt(i);
                if (Databas.DeerList.Count == 0)
                    ns.Extinct("Roe Deer");
            }
        }
        for (int i = 0; i < Databas.MooseList.Count; i++)
        {
            MooseInfo m = Databas.MooseList[i];
            if (!update_moose(m, 0.10, 0.1))
            {
                Databas.MooseList.RemoveAt(i);
                if (Databas.MooseList.Count == 0)
                    ns.Extinct("Moose");
            }
        }

        //Then continue with omnivores
        for (int i = 0; i < Databas.SquirrelList.Count; i++)
        {
            SquirrelInfo s = Databas.SquirrelList[i];
            if (!update_squirell(s, 0.4, 0.35))
            {
                Databas.SquirrelList.RemoveAt(i);
                if (Databas.SquirrelList.Count == 0)
                    ns.Extinct("Squirrel");
            }
        }
        for (int i = 0; i < Databas.RatList.Count; i++)
        {
            RatInfo r = Databas.RatList[i];
            if (!update_rat(r, 0.25, 0.20))
            {
                Databas.RatList.RemoveAt(i);
                if (Databas.RatList.Count == 0)
                    ns.Extinct("Rat");
            }
        }
        for (int i = 0; i < Databas.BoarList.Count; i++)
        {
            WildBoarInfo b = Databas.BoarList[i];
            if (!update_boar(b, 0.15, 0.10))
            {
                Databas.BoarList.RemoveAt(i);
                if (Databas.BoarList.Count == 0)
                    ns.Extinct("Boar");
            }
        }
        for (int i = 0; i < Databas.BrownBearList.Count; i++)
        {
            BrownBearInfo b = Databas.BrownBearList[i];
            if (!update_brownBear(b, 0.10, 0.05))
            {
                Databas.BrownBearList.RemoveAt(i);
                if (Databas.BrownBearList.Count == 0)
                    ns.Extinct("Brown Bear");
            }
        }

        //finally go through the carnivores
        for (int i = 0; i < Databas.ShrewList.Count; i++)
        {
            ShrewInfo s = Databas.ShrewList[i];
            if (!update_shrew(s, 0.4, 0.35))
            {
                Databas.ShrewList.RemoveAt(i);
                if (Databas.ShrewList.Count == 0)
                    ns.Extinct("Shrew");
            }// throws in the whole array element (s) into the function
        }
        for (int i = 0; i < Databas.WeaselList.Count; i++)
        {
            WeaselInfo w = Databas.WeaselList[i];
            if (!update_weasel(w, 0.25, 0.20))
            {
                Databas.WeaselList.RemoveAt(i);
                if (Databas.WeaselList.Count == 0)
                    ns.Extinct("Weasel");
            }// throws in the whole array element (s) into the function
        }
        for (int i = 0; i < Databas.FoxList.Count; i++)
        {
            FoxInfo f = Databas.FoxList[i];
            if (!update_fox(f, 0.20, 0.15))
            {
                Databas.FoxList.RemoveAt(i);
                if (Databas.FoxList.Count == 0)
                    ns.Extinct("Fox");
            }// throws in the whole array element (s) into the function
        }
        for (int i = 0; i < Databas.WolfList.Count; i++)
        {
            WolfInfo w = Databas.WolfList[i];
            if (!update_wolf(w, 0.15, 0.10))
            {
                Databas.WolfList.RemoveAt(i);
                if (Databas.WolfList.Count == 0)
                    ns.Extinct("Wolf");
            }
        }

    }

    // Comments for herbivores are in update_mouse(). Comment for special case in update_moose()
    bool update_mouse(MouseInfo Targetanimal, double growth, double decrease)
    {

        Mouse animal = Targetanimal;
        string pos = Targetanimal.TilePosition; //the tile that the animal occupies.


        //local variables to get a delta population
        int beforeChangedPop;
        int afterChangedPop;
        double capPop; //set max cap on population.
        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))//check the Tile dictionary for tile with string "pos" exist
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; // Tile exists place in variable t

            if (t.name == pos) //if we are at the correct tile.
            {
                capPop = animal.population * animal.foodNeeded; //dynamically setting the max population for the animal on the tile based on amount of food.
                if (t.vegetationOnTile >= animal.foodNeeded && t.staticVegetationOnTile * 0.10 > capPop) //0.1 means that the population cap lets them eat tops 10% of available food. 
                {
                   
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hasEatenVeg = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population; 
                        if (animal.hungryYears > 1) //if the animal was hungry prior to satisfiedYears == 2 then they get a growth penalty 
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //increasing the population with penalty.
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //increasing the population.
                        }
                        afterChangedPop = animal.population;
                        animal.hungryYears = 0; 
                        //updating meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //updating vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness += 2;
                }
                else if (t.vegetationOnTile < animal.foodNeeded) //they can be satisfied 
                {
                    animal.satisfiedYears = 0; 
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        beforeChangedPop = animal.population;
                        animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease); //decreasing the population
                        afterChangedPop = animal.population;
                        //updating meatOnTile level if population starves
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                        //updating vegetationOnTile if population starves (releasing the food they needed before dying)
                        if (animal.hasEatenVeg)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }

                        if (animal.population <= 0) //the animal population died from starvation.
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                            return false;
                        }
                        ns.AnimalHungry("Mouse", pos); //notifies that the animal is hungry.
                    }
                }
                else//they are satisfied
                {
                    if (animal.satisfiedYears > 15) //random value for happy years
                    {
                        //a random sickness generator, to make the game less static.
                        System.Random rnd = new System.Random();
                        int stable = rnd.Next(1, 40);
                        if (stable == 7)
                        {
                            ns.Sickness("Mouse", pos); //notifies that the animal got sick
                            double tempPop = animal.population;
                            animal.population = (int)Math.Ceiling(animal.population * 0.50);
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((tempPop - animal.population) * animal.foodNeeded);
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((tempPop - animal.population) * animal.meatValue);

                        }
                    }
                    animal.satisfiedYears++;
                    Happiness++;
                }
            }
        }
        return true; //the animal population isn't 0
    }
    bool update_hare(HareInfo Targetanimal, double growth, double decrease)
    {
        Hare animal = Targetanimal;
        string pos = Targetanimal.TilePosition;
        double capPop;
        int beforeChangedPop;
        int afterChangedPop;


        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; 

            if (t.name == pos)
            {
                capPop = animal.population * animal.foodNeeded;
                if (t.vegetationOnTile >= animal.foodNeeded && t.staticVegetationOnTile * 0.20 > capPop) 
                {
                    animal.satisfiedYears++; 
                    animal.hasEatenVeg = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0)
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); 
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        }
                        afterChangedPop = animal.population;
                        animal.hungryYears = 0;
                      
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                       
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness += 2;
                }
                else if (t.vegetationOnTile < animal.foodNeeded)
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        beforeChangedPop = animal.population;
                        animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                        afterChangedPop = animal.population;
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);

                        if (animal.hasEatenVeg)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }

                        if (animal.population <= 0)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                            return false;
                        }
                        ns.AnimalHungry("Hare", pos);
                    }
                }
                else
                {
                    if (animal.satisfiedYears > 15)
                    {
                        System.Random rnd = new System.Random();
                        int stable = rnd.Next(1, 40);
 
                        if (stable == 5)
                        {
                            ns.Sickness("Hare", pos);
                            double tempPop = animal.population;
                            animal.population = (int)Math.Ceiling(animal.population * 0.50);
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((tempPop - animal.population) * animal.foodNeeded);
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((tempPop - animal.population) * animal.meatValue);
                        }
                    }
                    animal.satisfiedYears++;
                    Happiness++;
                }
            }
        }
        return true;
    }
    bool update_deer(DeerInfo Targetanimal, double growth, double decrease)
    {
        RoeDeer animal = Targetanimal;
        string pos = Targetanimal.TilePosition;
        double capPop;

        int beforeChangedPop;
        int afterChangedPop;


        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos];

            if (t.name == pos)
            {
                capPop = animal.population * animal.foodNeeded;
                if (t.vegetationOnTile >= animal.foodNeeded && t.staticVegetationOnTile * 0.5 > capPop) 
                {
                    animal.satisfiedYears++; 
                    animal.hasEatenVeg = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) 
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2));
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        }
                        afterChangedPop = animal.population;
                        animal.hungryYears = 0;
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness += 2;
                }
                else if (t.vegetationOnTile < animal.foodNeeded)
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        beforeChangedPop = animal.population;
                        animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                        afterChangedPop = animal.population;
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                        if (animal.hasEatenVeg)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }

                        if (animal.population <= 0)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                            return false;
                        }
                        ns.AnimalHungry("Roe Deer", pos);
                    }
                }
                else
                {
                    if (animal.satisfiedYears > 15)
                    {
                        System.Random rnd = new System.Random();
                        int stable = rnd.Next(1, 40);
                        if (stable == 3)
                        {
                            ns.Sickness("Roe Deer", pos);
                            double tempPop = animal.population;
                            animal.population = (int)Math.Ceiling(animal.population * 0.70);
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((tempPop - animal.population) * animal.foodNeeded);
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((tempPop - animal.population) * animal.meatValue);
                        }
                    }
                    animal.satisfiedYears++;
                    Happiness++;
                }
            }
        }
        return true;
    }
    bool update_moose(MooseInfo Targetanimal, double growth, double decrease)
    {
        Moose animal = Targetanimal;
        string pos = Targetanimal.TilePosition;
        int beforeChangedPop;
        int afterChangedPop;

        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; 

            if (t.name == pos)
            {
                if (t.vegetationOnTile >= animal.foodNeeded)
                {
                  
                    animal.satisfiedYears++;
                    animal.hasEatenVeg = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) 
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); 
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        }
                        afterChangedPop = animal.population;
                        animal.hungryYears = 0;

                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness += 2;
                }
                else if (t.vegetationOnTile < animal.foodNeeded) 
                {
                    //the animal releases the food it needs before checking that the vegetation is truly lesser than the vegetation it needs.
                    double enoughfood = globalTiles.Find(x => x.name == pos).vegetationOnTile + animal.foodNeeded;

                    //if the now updated food is sufficient, the animal isn't hungry and therefore doesn't need to decrease the population.
                    if (enoughfood >= animal.population * animal.foodNeeded)
                    {
                        animal.hungryYears = 0;
                    }

                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        beforeChangedPop = animal.population;
                        animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                        afterChangedPop = animal.population;

                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);

                        if (animal.hasEatenVeg)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }

                        if (animal.population <= 0)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                            return false;
                        }
                        ns.AnimalHungry("Moose", pos);
                    }
                }
                else
                {
                    if (animal.satisfiedYears > 15)
                    {
                        System.Random rnd = new System.Random();
                        int stable = rnd.Next(1, 40);

                        if (stable == 11)
                        {
                            ns.Sickness("Moose", pos);
                            double tempPop = animal.population;
                            animal.population = (int)Math.Ceiling(animal.population * 0.50);
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((tempPop - animal.population) * animal.foodNeeded);
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((tempPop - animal.population) * animal.meatValue);
                        }
                    }
                    animal.satisfiedYears++;
                    Happiness++;
                }
            }
        }
        return true;
    }


    //The omnivores can eat both vegetation and meat but they prefer vegetation. They will look for vegation first and as a last resort eat meat.
    //The comments for the vegation part is in update_mouse. BrownBear has the same special case as update_moose()
    bool update_squirell(SquirrelInfo Targetanimal, double growth, double decrease)
    {
        Squirrel animal = Targetanimal;
        string pos = Targetanimal.TilePosition;

        double capPop;

        int beforeChangedPop;
        int afterChangedPop;


        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos];

            if (t.name == pos)
            {
                capPop = animal.population * animal.foodNeeded;
                if (t.vegetationOnTile >= animal.foodNeeded && t.staticVegetationOnTile * 0.15 > capPop)
                {

                    animal.satisfiedYears++;
                    animal.hasEatenVeg = true;
                    animal.hasEatenMeat = false; 
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) 
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); 
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        }
                        afterChangedPop = animal.population;
                        //if the animal ate meat the year before but can eat vegetaton now, release the meat it needed.
                        if (animal.hasEatenMeat)
                        {
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                            animal.hasEatenMeat = false; //the animal is eating vegetation now...
                        }
                        animal.hungryYears = 0;

                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness+=2;
                }
                else if (t.meatOnTile >= animal.foodNeeded && t.staticVegetationOnTile * 0.15 > capPop) //if there is no vegetation left, eat meat
                {
                   
                    animal.satisfiedYears++; 
                    animal.hasEatenMeat = true;
                    animal.hasEatenVeg = false; //eating meat.
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //updating the population with penalty
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //updating the population
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;

                        //if the animal has eaten vegetation prior to this, release the meat it ate.
                        if (animal.hasEatenVeg)
                        {
                            //not 100% accurate, but it will have to do since time is limited
                            globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                            //set hasEatenMeat to false so we don't increase the meatlevel more than it actually ate.
                            animal.hasEatenVeg = false;
                        }
                        //updating meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //updating vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness+=2;
                }
                else if (t.meatOnTile < animal.foodNeeded && t.vegetationOnTile < animal.foodNeeded)
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        beforeChangedPop = animal.population;
                        animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                        afterChangedPop = animal.population;
                        //updating meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                        //updating vegetationOnTile if population rises
                        if (animal.hasEatenMeat)
                        {
                            globalTiles.Find(x => x.name == pos).meatOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                            
                        }
                        //release the vegetation
                        //setting new vegetationOnTile if population rises
                        if (animal.hasEatenVeg)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }


                        //maybe we should release the amount of meatOnTile as well? Complex question since if they only ate vegetation, releasing MeatOnTile will rocket. The same if it is the other way around...
                    }
                    if (animal.population <= 0)
                    {
                        return false;
                    }
                    ns.AnimalHungry("Squirrel", pos);
                }
                else//they are satisfied
                {
                    if (animal.satisfiedYears > 15)
                    {
                        System.Random rnd = new System.Random();
                        int stable = rnd.Next(1, 40);
                        //Random sickness, to change the population sometimes
                        if (stable == 13)
                        {
                            ns.Sickness("Squirrel", pos);
                            double tempPop = animal.population;
                            animal.population = (int)Math.Ceiling(animal.population * 0.50);
                            if (animal.hasEatenMeat)
                            {
                                globalTiles.Find(x => x.name == pos).meatOnTile += ((tempPop - animal.population) * animal.foodNeeded);
                            }
                            else
                            {
                                globalTiles.Find(x => x.name == pos).vegetationOnTile += ((tempPop - animal.population) * animal.foodNeeded);
                            }
                        }
                    }
                    animal.satisfiedYears++;
                    Happiness++;
                }
            }
        }
        return true;
    }
    bool update_rat(RatInfo Targetanimal, double growth, double decrease)
    {
        Rat animal = Targetanimal;
        string pos = Targetanimal.TilePosition;
        double capPop;

        int beforeChangedPop;
        int afterChangedPop;


        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; 

            if (t.name == pos)
            {
                capPop = animal.population * animal.foodNeeded;
                if (t.vegetationOnTile >= animal.foodNeeded && t.staticVegetationOnTile * 0.25 > capPop)
                {

                    animal.satisfiedYears++;
                    animal.hasEatenVeg = true;
                    animal.hasEatenMeat = false; 
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) 
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2));
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        }
                        afterChangedPop = animal.population;
                        if (animal.hasEatenMeat)
                        {
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                            animal.hasEatenMeat = false;
                        }

                        animal.hungryYears = 0;
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness+=2;
                }
                else if (t.meatOnTile >= animal.foodNeeded && t.staticVegetationOnTile * 0.15 > capPop)
                {
                    animal.satisfiedYears++; 
                    animal.hasEatenMeat = true;
                    animal.hasEatenVeg = false; 
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) 
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2));
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;

                        if (animal.hasEatenVeg)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                            animal.hasEatenVeg = false;
                        }
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness+=2;
                }
                else if (t.meatOnTile < animal.foodNeeded && t.vegetationOnTile < animal.foodNeeded)
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        beforeChangedPop = animal.population;
                        animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                        afterChangedPop = animal.population;
                        
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                       
                        if (animal.hasEatenMeat)
                        {
                            globalTiles.Find(x => x.name == pos).meatOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }
                        if (animal.hasEatenVeg)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }
                    }
                    if (animal.population <= 0)
                    {
                        return false;
                    }
                    ns.AnimalHungry("Rat", pos);
                }
                else
                {
                    if (animal.satisfiedYears > 15)
                    {
                        System.Random rnd = new System.Random();
                        int stable = rnd.Next(1, 40);
                        if (stable == 17)
                        {
                            ns.Sickness("Rat", pos);
                            double tempPop = animal.population;
                            animal.population = (int)Math.Ceiling(animal.population * 0.50);
                            if (animal.hasEatenMeat)
                            {
                                globalTiles.Find(x => x.name == pos).meatOnTile += ((tempPop - animal.population) * animal.foodNeeded);
                            }
                            else
                            {
                                globalTiles.Find(x => x.name == pos).vegetationOnTile += ((tempPop - animal.population) * animal.foodNeeded);
                            }
                        }
                    }
                    animal.satisfiedYears++;
                    Happiness++;
                }
            }
        }
        return true;
    }
    bool update_boar(WildBoarInfo Targetanimal, double growth, double decrease)
    {

        Boar animal = Targetanimal;
        string pos = Targetanimal.TilePosition;
        double capPop;

        int beforeChangedPop;
        int afterChangedPop;


        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos];

            if (t.name == pos)
            {
                capPop = animal.population * animal.foodNeeded;
                if (t.vegetationOnTile >= animal.foodNeeded && t.staticVegetationOnTile * 0.45 > capPop)
                {

                    animal.satisfiedYears++;
                    animal.hasEatenVeg = true;
                    animal.hasEatenMeat = false;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) 
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2));
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); 
                        }
                        afterChangedPop = animal.population;
                        if (animal.hasEatenMeat)
                        {
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                            animal.hasEatenMeat = false;
                        }

                        animal.hungryYears = 0;
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness+=2;
                }
                else if (t.meatOnTile >= animal.foodNeeded && t.staticVegetationOnTile * 0.15 > capPop) 
                {
                    animal.satisfiedYears++;
                    animal.hasEatenMeat = true;
                    animal.hasEatenVeg = false;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) 
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2));
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;
                        if (animal.hasEatenVeg)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                            animal.hasEatenVeg = false;
                        }
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness+=2;
                }
                else if (t.meatOnTile < animal.foodNeeded && t.vegetationOnTile < animal.foodNeeded)
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        beforeChangedPop = animal.population;
                        animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                        afterChangedPop = animal.population;
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                        if (animal.hasEatenMeat)
                        {
                            globalTiles.Find(x => x.name == pos).meatOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }
                        if (animal.hasEatenVeg)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }

                    }
                    if (animal.population <= 0)
                    {
                        return false;
                    }
                    ns.AnimalHungry("Boar", pos);

                }
                else
                {
                    if (animal.satisfiedYears > 15)
                    {
                        System.Random rnd = new System.Random();
                        int stable = rnd.Next(1, 40);
                        if (stable == 13)
                        {
                            ns.Sickness("Boar", pos);
                            double tempPop = animal.population;
                            animal.population = (int)Math.Ceiling(animal.population * 0.50);
                            if (animal.hasEatenMeat)
                            {
                                globalTiles.Find(x => x.name == pos).meatOnTile += ((tempPop - animal.population) * animal.foodNeeded);
                            }
                            else
                            {
                                globalTiles.Find(x => x.name == pos).vegetationOnTile += ((tempPop - animal.population) * animal.foodNeeded);
                            }
                        }
                    }
                    animal.satisfiedYears++;
                    Happiness++;
                }
            }
        }
        return true;
    }
    bool update_brownBear(BrownBearInfo Targetanimal, double growth, double decrease)
    {
        BrownBear animal = Targetanimal;
        string pos = Targetanimal.TilePosition;
        int beforeChangedPop;
        int afterChangedPop;


        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos];

            if (t.name == pos)
            {
                if (t.vegetationOnTile >= animal.foodNeeded)
                {
                    animal.satisfiedYears++;
                    animal.hasEatenVeg = true;
                    animal.hasEatenMeat = false;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) 
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); 
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); 
                        }
                        afterChangedPop = animal.population;
                        if (animal.hasEatenMeat)
                        {
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                            animal.hasEatenMeat = false;
                        }
                        animal.hungryYears = 0;
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness+=2;
                }
                else if (t.meatOnTile >= animal.foodNeeded)
                {
                    animal.satisfiedYears++;
                    animal.hasEatenMeat = true;
                    animal.hasEatenVeg = false;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) 
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2));
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;
                        if (animal.hasEatenVeg)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                            animal.hasEatenVeg = false;
                        }
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness+=2;
                }
                else if (t.meatOnTile < animal.foodNeeded && t.vegetationOnTile < animal.foodNeeded)
                {
                    double enoughfood = 0;
                 
                    if (animal.hasEatenMeat)
                    {
                        enoughfood = globalTiles.Find(x => x.name == pos).meatOnTile + animal.foodNeeded;
                    }
                    else if(animal.hasEatenVeg)
                    {
                         enoughfood = globalTiles.Find(x => x.name == pos).vegetationOnTile + animal.foodNeeded;
                    }
                    if (enoughfood >= animal.population * animal.foodNeeded)
                    {
                        animal.hungryYears = 0;
                    }

                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        beforeChangedPop = animal.population;
                        animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                        afterChangedPop = animal.population;
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                        if (animal.hasEatenMeat)
                        {
                            globalTiles.Find(x => x.name == pos).meatOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }
                        if (animal.hasEatenVeg)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }
                    }
                    if (animal.population <= 0)
                    {
                        return false;
                    }
                    ns.AnimalHungry("Brown Bear", pos);

                }
                else
                {
                    if (animal.satisfiedYears > 15)
                    {
                        System.Random rnd = new System.Random();
                        int stable = rnd.Next(1, 40);
                        if (stable == 13)
                        {
                            ns.Sickness("Brown Bear", pos);
                            double tempPop = animal.population;
                            animal.population = (int)Math.Ceiling(animal.population * 0.50);
                            if(animal.hasEatenMeat)
                            {
                                globalTiles.Find(x => x.name == pos).meatOnTile += ((tempPop - animal.population) * animal.foodNeeded);
                            }
                            else
                            {
                                globalTiles.Find(x => x.name == pos).vegetationOnTile += ((tempPop - animal.population) * animal.foodNeeded);
                            }
                            
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((tempPop - animal.population) * animal.meatValue);
                        }
                    }
                    animal.satisfiedYears++;
                    Happiness++;
                }
            }
        }
        return true;
    }
    
    //The carnivores method does the same thing as herbivores, but we are checking meatNeeded instead of vegNeeded.
    //update_wolf() has the same special case as update_moose().
    bool update_shrew(ShrewInfo Targetanimal, double growth, double decrease)
    {
        Shrew animal = Targetanimal;
        string pos = Targetanimal.TilePosition;

        int beforeChangedPop;
        int afterChangedPop;
        double capPop; 
        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos];

            if (t.name == pos)
            {
                capPop = animal.population * animal.foodNeeded;
                if (t.meatOnTile >= animal.foodNeeded && capPop < 40.0)
                {
                    animal.satisfiedYears++;
                    animal.hasEatenMeat = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) 
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2));
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness+=2;
                }
                else if (t.meatOnTile < animal.foodNeeded)
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        beforeChangedPop = animal.population;
                        animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                        afterChangedPop = animal.population;
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                        if (animal.hasEatenMeat)
                        {
                            globalTiles.Find(x => x.name == pos).meatOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }
                        if (animal.population <= 0)
                        {
                            return false;
                        }
                        ns.AnimalHungry("Shrew", pos);
                    }
                }
                else
                {
                    if (animal.satisfiedYears > 15)
                    {
                        System.Random rnd = new System.Random();
                        int stable = rnd.Next(1, 40);
                        if (stable == 7)
                        {
                            ns.Sickness("Shrew", pos);
                            double tempPop = animal.population;
                            animal.population = (int)Math.Ceiling(animal.population * 0.50);
                            globalTiles.Find(x => x.name == pos).meatOnTile += ((tempPop - animal.population) * animal.foodNeeded);
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((tempPop - animal.population) * animal.meatValue);

                        }
                    }
                    animal.satisfiedYears++;
                    Happiness++;
                }
            }

        }
        return true;
    }
    bool update_weasel(WeaselInfo Targetanimal, double growth, double decrease)
    {
        Weasel animal = Targetanimal;
        string pos = Targetanimal.TilePosition;
        int beforeChangedPop;
        int afterChangedPop;
        double capPop;
        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos];

            if (t.name == pos)
            {
                capPop = animal.population * animal.foodNeeded;
                if (t.meatOnTile >= animal.foodNeeded && capPop < 20.0)
                {
                    animal.satisfiedYears++;
                    animal.hasEatenMeat = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) 
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2));
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness+=2;
                }
                else if (t.meatOnTile < animal.foodNeeded)
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        beforeChangedPop = animal.population;
                        animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                        afterChangedPop = animal.population;
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                        if (animal.hasEatenMeat)
                        {
                            globalTiles.Find(x => x.name == pos).meatOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }
                        if (animal.population <= 0)
                        {
                            return false;
                        }
                        ns.AnimalHungry("Weasel", pos);
                    }
                }
                else
                {
                    if (animal.satisfiedYears > 15)
                    {
                        System.Random rnd = new System.Random();
                        int stable = rnd.Next(1, 40);
                        if (stable == 7)
                        {
                            ns.Sickness("Weasel", pos);
                            double tempPop = animal.population;
                            animal.population = (int)Math.Ceiling(animal.population * 0.50);
                            globalTiles.Find(x => x.name == pos).meatOnTile += ((tempPop - animal.population) * animal.foodNeeded);
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((tempPop - animal.population) * animal.meatValue);

                        }
                    }
                    animal.satisfiedYears++;
                    Happiness++;
                }
            }

        }
        return true;
    }        
    bool update_fox(FoxInfo Targetanimal, double growth, double decrease)
    {
        Fox animal = Targetanimal;
        string pos = Targetanimal.TilePosition;
        int beforeChangedPop;
        int afterChangedPop;
        double capPop;
        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos];

            if (t.name == pos)
            {
                capPop = animal.population * animal.foodNeeded;
                if (t.meatOnTile >= animal.foodNeeded && capPop < 8.0)
                {
                    animal.satisfiedYears++;
                    animal.hasEatenMeat = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0)
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2));
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness+=2;
                }
                else if (t.meatOnTile < animal.foodNeeded)
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        beforeChangedPop = animal.population;
                        animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                        afterChangedPop = animal.population;
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                        if (animal.hasEatenMeat)
                        {
                            globalTiles.Find(x => x.name == pos).meatOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }
                        if (animal.population <= 0)
                        {
                            return false;
                        }
                        ns.AnimalHungry("Fox", pos);
                    }
                }
                else
                {
                    if (animal.satisfiedYears > 15)
                    {
                        System.Random rnd = new System.Random();
                        int stable = rnd.Next(1, 40);
                        if (stable == 19)
                        {
                            ns.Sickness("Fox", pos);
                            double tempPop = animal.population;
                            animal.population = (int)Math.Ceiling(animal.population * 0.50);
                            globalTiles.Find(x => x.name == pos).meatOnTile += ((tempPop - animal.population) * animal.foodNeeded);
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((tempPop - animal.population) * animal.meatValue);
                        }
                    }
                    animal.satisfiedYears++;
                    Happiness++;
                }
            }

        }
        return true;
    }
    bool update_wolf(WolfInfo Targetanimal, double growth, double decrease)
    {
        Wolf animal = Targetanimal;
        string pos = Targetanimal.TilePosition;
        int beforeChangedPop;
        int afterChangedPop;

        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos];

            if (t.meatOnTile >= animal.foodNeeded)
            {
                animal.satisfiedYears++;
                animal.hasEatenMeat = true;
                if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) 
                {
                    beforeChangedPop = animal.population;
                    if (animal.hungryYears > 1)
                    {
                        animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); 
                    }
                    else
                    {
                        animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                    }
                    animal.hungryYears = 0;
                    afterChangedPop = animal.population;
                    globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                    globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                }
                Happiness+=2;
            }
            else if(t.meatOnTile < animal.foodNeeded)
            {
                double enoughfood = globalTiles.Find(x => x.name == pos).meatOnTile + animal.foodNeeded;
                if (enoughfood >= animal.population * animal.foodNeeded)
                {
                    animal.hungryYears = 0;
                }

                animal.satisfiedYears = 0;
                animal.hungryYears++;
                if (animal.hungryYears >= 2)
                {
                    beforeChangedPop = animal.population;
                    animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                    afterChangedPop = animal.population;
                    globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                    if (animal.hasEatenMeat)
                    {
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                    }
                    if (animal.population <= 0)
                    {
                        return false;
                    }
                    ns.AnimalHungry("Wolf", pos);
                }
            }
            else
            {
                if (animal.satisfiedYears > 15)
                {
                    System.Random rnd = new System.Random();
                    int stable = rnd.Next(1, 40);
                    if (stable == 11)
                    {
                        ns.Sickness("Wolf", pos);
                        double tempPop = animal.population;
                        animal.population = (int)Math.Ceiling(animal.population * 0.50);
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((tempPop - animal.population) * animal.foodNeeded);
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((tempPop - animal.population) * animal.meatValue);
                    }
                }
                animal.satisfiedYears++;
                Happiness++;
            }
        }
        return true;
     }
}










