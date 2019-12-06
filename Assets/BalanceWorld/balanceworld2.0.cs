﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BalanceWorld : MonoBehaviour
{

    List<TileClass> globalTiles = new List<TileClass>();
    public static TileClass tile { get; set; }
    private Global_Database Databas;
    public int Happiness;


    public BalanceWorld()
    {
        //globalTiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
    }


    //we are hoping that tiles is what we want it to be.

    // Update is called once per year
    public void YearUpdate()
    {
        Happiness = 0;
        Databas = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().globalDatabase;
        globalTiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().Getlist();

        //gå igenom vectorn med djur och sätt ett meat värde på de tiles där djur finns.

        //start with herbivores
        for (int i = 0; i < Databas.MouseList.Count; i++)
        {
            MouseInfo m = Databas.MouseList[i];
            if (!update_mouse(m, 0.4, 0.35))
            {
                Databas.MouseList.RemoveAt(i);
            }// throws in the whole array element (s) into the function
        }
        for (int i = 0; i < Databas.HareList.Count; i++)
        {
            HareInfo h = Databas.HareList[i];
            if (!update_hare(h, 0.27, 0.22))
            {
                Databas.HareList.RemoveAt(i);
            }
        }
        for (int i = 0; i < Databas.DeerList.Count; i++)
        {
            DeerInfo d = Databas.DeerList[i];
            if (!update_deer(d, 0.20, 0.15))
            {
                Databas.DeerList.RemoveAt(i);
            }
        }
        for (int i = 0; i < Databas.MooseList.Count; i++)
        {
            MooseInfo m = Databas.MooseList[i];
            if (!update_moose(m, 0.10, 0.1))
            {
                Databas.MooseList.RemoveAt(i);
            }
        }

        //Then continue with omnivores
        for (int i = 0; i < Databas.SquirrelList.Count; i++)
        {
            SquirrelInfo s = Databas.SquirrelList[i];
            if (!update_squirell(s, 0.4, 0.35))
            {
                Databas.SquirrelList.RemoveAt(i);
            }
        }
        for (int i = 0; i < Databas.RatList.Count; i++)
        {
            RatInfo r = Databas.RatList[i];
            if (!update_rat(r, 0.25, 0.20))
            {
                Databas.RatList.RemoveAt(i);
            }
        }
        for (int i = 0; i < Databas.BoarList.Count; i++)
        {
            WildBoarInfo b = Databas.BoarList[i];
            if (!update_boar(b, 0.15, 0.10))
            {
                Databas.BoarList.RemoveAt(i);
            }
        }
        for (int i = 0; i < Databas.BrownBearList.Count; i++)
        {
            BrownBearInfo b = Databas.BrownBearList[i];
            if (!update_brownBear(b, 0.10, 0.05))
            {
                Databas.BrownBearList.RemoveAt(i);
            }
        }


        //finally go through the carnivores

        for (int i = 0; i < Databas.ShrewList.Count; i++)
        {
            ShrewInfo s = Databas.ShrewList[i];
            if (!update_shrew(s, 0.4, 0.35))
            {
                Databas.ShrewList.RemoveAt(i);
            }// throws in the whole array element (s) into the function
        }
        for (int i = 0; i < Databas.WeaselList.Count; i++)
        {
            WeaselInfo w = Databas.WeaselList[i];
            if (!update_weasel(w, 0.25, 0.20))
            {
                Databas.WeaselList.RemoveAt(i);
            }// throws in the whole array element (s) into the function
        }
        for (int i = 0; i < Databas.FoxList.Count; i++)
        {
            FoxInfo f = Databas.FoxList[i];
            if (!update_fox(f, 0.20, 0.15))
            {

                Databas.FoxList.RemoveAt(i);
            }// throws in the whole array element (s) into the function
        }
        for (int i = 0; i < Databas.WolfList.Count; i++)
        {
            WolfInfo w = Databas.WolfList[i];
            if (!update_wolf(w, 0.15, 0.10))
            {
                Databas.WolfList.RemoveAt(i);
            }
        }

    }


    // Comments for herbivores are in update_mouse
    bool update_mouse(MouseInfo Targetanimal, double growth, double decrease)
    {

        Mouse animal = Targetanimal;
        string pos = Targetanimal.TilePosition; //the tile that the animal occupies.


        // take in the global vector that holds the herbivore coordinate

        //local variables to get a delta population
        int beforeChangedPop;
        int afterChangedPop;

        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))//check the Tile dictionary for tile with string "pos" exist
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; // Tile exists place in variable t

            if (t.name == pos)
            {
                //vi måste ta in objekten från listan, kolla vilken Tile*range familjen är på, antal av arten * foodNeeded variabeln för den familjen. Sen när det är klart
                //så måste vi uppdatera available food på den tilen * range

                if (t.vegetationOnTile >= animal.foodNeeded)
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hasEaten = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //increasing the population.
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //increasing the population.
                        }
                        afterChangedPop = animal.population;
                        animal.hungryYears = 0;
                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness++;
                }
                else
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        beforeChangedPop = animal.population;
                        animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                        afterChangedPop = animal.population;
                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                        //setting new vegetationOnTile if population rises
                        if (animal.hasEaten)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }

                        if (animal.population <= 0)
                        {

                            return false;
                        }
                    }
                }
            }
        }
        Debug.Log("Number of mice: " + ": " + Targetanimal.population);

        return true;
    }

    bool update_hare(HareInfo Targetanimal, double growth, double decrease)
    {
        Hare animal = Targetanimal;
        string pos = Targetanimal.TilePosition;

        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        // take in the global vector that holds the herbivore coordinate


        int beforeChangedPop;
        int afterChangedPop;


        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))//check the Tile dictionary for tile with string "pos" exist
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; // Tile exists place in variable t

            if (t.name == pos)
            {
                //vi måste ta in objekten från listan, kolla vilken Tile*range familjen är på, antal av arten * foodNeeded variabeln för den familjen. Sen när det är klart
                //så måste vi uppdatera available food på den tilen * range

                if (t.vegetationOnTile >= animal.foodNeeded)
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hasEaten = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //increasing the population.
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //increasing the population.
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness++;
                }
                else
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        beforeChangedPop = animal.population;
                        animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                        afterChangedPop = animal.population;
                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                        //setting new vegetationOnTile if population rises
                        if (animal.hasEaten)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }

                        if (animal.population <= 0)
                        {
                            return false;
                        }
                    }
                }
            }
        }
        Debug.Log("Number of hares : " + ": " + Targetanimal.population);
        return true;
    }

    bool update_deer(DeerInfo Targetanimal, double growth, double decrease)
    {
        RoeDeer animal = Targetanimal;
        string pos = Targetanimal.TilePosition;

        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        // take in the global vector that holds the herbivore coordinate

        int beforeChangedPop;
        int afterChangedPop;

        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))//check the Tile dictionary for tile with string "pos" exist
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; // Tile exists place in variable t

            if (t.name == pos)
            {
                //vi måste ta in objekten från listan, kolla vilken Tile*range familjen är på, antal av arten * foodNeeded variabeln för den familjen. Sen när det är klart
                //så måste vi uppdatera available food på den tilen * range

                if (t.vegetationOnTile >= animal.foodNeeded)
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hasEaten = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //increasing the population.
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //increasing the population.
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness++;
                }
                else
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        beforeChangedPop = animal.population;
                        animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                        afterChangedPop = animal.population;
                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                        //setting new vegetationOnTile if population rises
                        if (animal.hasEaten)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }



                        if (animal.population <= 0)
                        {
                            return false;
                        }
                    }
                }
            }
        }
        Debug.Log("Number of deers : " + ": " + Targetanimal.population);
        return true;
    }
    bool update_moose(MooseInfo Targetanimal, double growth, double decrease)
    {
        Moose animal = Targetanimal;
        string pos = Targetanimal.TilePosition;

        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        // take in the global vector that holds the herbivore coordinate

        int beforeChangedPop;
        int afterChangedPop;

        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))//check the Tile dictionary for tile with string "pos" exist
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; // Tile exists place in variable t

            if (t.name == pos)
            {
                //vi måste ta in objekten från listan, kolla vilken Tile*range familjen är på, antal av arten * foodNeeded variabeln för den familjen. Sen när det är klart
                //så måste vi uppdatera available food på den tilen * range

                if (t.vegetationOnTile >= animal.foodNeeded)
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hasEaten = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //increasing the population.
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //increasing the population.
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness++;
                }
                else
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        beforeChangedPop = animal.population;
                        animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                        afterChangedPop = animal.population;
                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                        //setting new vegetationOnTile if population rises
                        if (animal.hasEaten)
                        {
                            globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }

                        if (animal.population <= 0)
                        {
                            return false;
                        }
                    }
                }
            }
        }
        Debug.Log("Number of mooses : " + ": " + Targetanimal.population);
        return true;
    }


    bool update_squirell(SquirrelInfo Targetanimal, double growth, double decrease)
    {
        Squirrel animal = Targetanimal;
        string pos = Targetanimal.TilePosition;
        bool meat = false;

        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        // take in the global vector that holds the herbivore coordinate

        int beforeChangedPop;
        int afterChangedPop;

        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))//check the Tile dictionary for tile with string "pos" exist
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; // Tile exists place in variable t

            if (t.name == pos)
            {
                //vi måste ta in objekten från listan, kolla vilken Tile*range familjen är på, antal av arten * foodNeeded variabeln för den familjen. Sen när det är klart
                //så måste vi uppdatera available food på den tilen * range

                if (t.vegetationOnTile >= animal.foodNeeded)
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hasEaten = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //increasing the population.
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //increasing the population.
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness++;
                }
                else if (t.meatOnTile >= animal.foodNeeded) //if there is no vegetation left, eat meat
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hasEaten = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //increasing the population.
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //increasing the population.
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness++;
                }
                else
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        if (meat)
                        {
                            beforeChangedPop = animal.population;
                            animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                            afterChangedPop = animal.population;
                            //setting new meatOnTile level if population rises
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                            //setting new vegetationOnTile if population rises
                            if (animal.hasEaten)
                            {
                                globalTiles.Find(x => x.name == pos).meatOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                            }
                        }
                        else //release the vegetation
                        {
                            beforeChangedPop = animal.population;
                            animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                            afterChangedPop = animal.population;
                            //setting new meatOnTile level if population rises
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                            //setting new vegetationOnTile if population rises
                            if (animal.hasEaten)
                            {
                                globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                            }

                        }

                        //maybe we should release the amount of meatOnTile as well? Complex question since if they only ate vegetation, releasing MeatOnTile will rocket. The same if it is the other way around...
                    }
                    if (animal.population <= 0)
                    {
                        return false;
                    }

                }

            }
        }
        Debug.Log("Number of squirells: " + ": " + Targetanimal.population);
        return true;
    }
    bool update_rat(RatInfo Targetanimal, double growth, double decrease)
    {
        Rat animal = Targetanimal;
        string pos = Targetanimal.TilePosition;
        bool meat = false;


        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        // take in the global vector that holds the herbivore coordinate

        int beforeChangedPop;
        int afterChangedPop;

        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))//check the Tile dictionary for tile with string "pos" exist
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; // Tile exists place in variable t

            if (t.name == pos)
            {
                //vi måste ta in objekten från listan, kolla vilken Tile*range familjen är på, antal av arten * foodNeeded variabeln för den familjen. Sen när det är klart
                //så måste vi uppdatera available food på den tilen * range

                if (t.vegetationOnTile >= animal.foodNeeded)
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hasEaten = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //increasing the population.
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //increasing the population.
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness++;
                }
                else if (t.meatOnTile >= animal.foodNeeded) //if there is no vegetation left, eat meat
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hasEaten = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //increasing the population.
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //increasing the population.
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness++;
                }
                else
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        if (meat)
                        {
                            beforeChangedPop = animal.population;
                            animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                            afterChangedPop = animal.population;
                            //setting new meatOnTile level if population rises
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                            //setting new vegetationOnTile if population rises
                            if (animal.hasEaten)
                            {
                                globalTiles.Find(x => x.name == pos).meatOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                            }
                        }
                        else //release the vegetation
                        {
                            beforeChangedPop = animal.population;
                            animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                            afterChangedPop = animal.population;
                            //setting new meatOnTile level if population rises
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                            //setting new vegetationOnTile if population rises
                            if (animal.hasEaten)
                            {
                                globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                            }

                        }
                        //maybe we should release the amount of meatOnTile as well? Complex question since if they only ate vegetation, releasing MeatOnTile will rocket. The same if it is the other way around...
                    }
                    if (animal.population <= 0)
                    {
                        return false;
                    }

                }

            }
        }
        Debug.Log("Number of rats : " + ": " + Targetanimal.population);
        return true;
    }
    bool update_boar(WildBoarInfo Targetanimal, double growth, double decrease)
    {

        Boar animal = Targetanimal;
        string pos = Targetanimal.TilePosition;
        bool meat = false;

        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        // take in the global vector that holds the herbivore coordinate

        int beforeChangedPop;
        int afterChangedPop;

        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))//check the Tile dictionary for tile with string "pos" exist
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; // Tile exists place in variable t

            if (t.name == pos)
            {
                //vi måste ta in objekten från listan, kolla vilken Tile*range familjen är på, antal av arten * foodNeeded variabeln för den familjen. Sen när det är klart
                //så måste vi uppdatera available food på den tilen * range

                if (t.vegetationOnTile >= animal.foodNeeded)
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hasEaten = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //increasing the population.
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //increasing the population.
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness++;
                }
                else if (t.meatOnTile >= animal.foodNeeded) //if there is no vegetation left, eat meat
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hasEaten = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //increasing the population.
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //increasing the population.
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness++;
                }
                else
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        if (meat)
                        {
                            beforeChangedPop = animal.population;
                            animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                            afterChangedPop = animal.population;
                            //setting new meatOnTile level if population rises
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                            //setting new vegetationOnTile if population rises
                            if (animal.hasEaten)
                            {
                                globalTiles.Find(x => x.name == pos).meatOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                            }
                        }
                        else //release the vegetation
                        {
                            beforeChangedPop = animal.population;
                            animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                            afterChangedPop = animal.population;
                            //setting new meatOnTile level if population rises
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                            //setting new vegetationOnTile if population rises
                            if (animal.hasEaten)
                            {
                                globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                            }

                        }
                        //maybe we should release the amount of meatOnTile as well? Complex question since if they only ate vegetation, releasing MeatOnTile will rocket. The same if it is the other way around...
                    }
                    if (animal.population <= 0)
                    {
                        return false;
                    }

                }

            }
        }
        Debug.Log("Number of wild boars : " + ": " + Targetanimal.population);
        return true;
    }
    bool update_brownBear(BrownBearInfo Targetanimal, double growth, double decrease)
    {
        BrownBear animal = Targetanimal;
        string pos = Targetanimal.TilePosition;
        bool meat = false;

        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        // take in the global vector that holds the herbivore coordinate

        int beforeChangedPop;
        int afterChangedPop;

        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))//check the Tile dictionary for tile with string "pos" exist
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; // Tile exists place in variable t

            if (t.name == pos)
            {
                //vi måste ta in objekten från listan, kolla vilken Tile*range familjen är på, antal av arten * foodNeeded variabeln för den familjen. Sen när det är klart
                //så måste vi uppdatera available food på den tilen * range

                if (t.vegetationOnTile >= animal.foodNeeded)
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hasEaten = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //increasing the population.
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //increasing the population.
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness++;
                }
                else if (t.meatOnTile >= animal.foodNeeded) //if there is no vegetation left, eat meat
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hasEaten = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //increasing the population.
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //increasing the population.
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                        meat = true;
                    }
                    Happiness++;
                }
                else
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        if (meat)
                        {
                            beforeChangedPop = animal.population;
                            animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                            afterChangedPop = animal.population;
                            //setting new meatOnTile level if population rises
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                            //setting new vegetationOnTile if population rises
                            if (animal.hasEaten)
                            {
                                globalTiles.Find(x => x.name == pos).meatOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                            }
                        }
                        else //release the vegetation
                        {
                            beforeChangedPop = animal.population;
                            animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                            afterChangedPop = animal.population;
                            //setting new meatOnTile level if population rises
                            globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                            //setting new vegetationOnTile if population rises
                            if (animal.hasEaten)
                            {
                                globalTiles.Find(x => x.name == pos).vegetationOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                            }

                        }
                        //maybe we should release the amount of meatOnTile as well? Complex question since if they only ate vegetation, releasing MeatOnTile will rocket. The same if it is the other way around...
                    }
                    if (animal.population <= 0)
                    {
                        return false;
                    }

                }

            }
        }
        Debug.Log("Number of brownBears : " + ": " + Targetanimal.population);
        return true;

    }

    bool update_shrew(ShrewInfo Targetanimal, double growth, double decrease)
    {
        Shrew animal = Targetanimal;
        string pos = Targetanimal.TilePosition;

        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        // take in the global vector that holds the herbivore coordinate

        int beforeChangedPop;
        int afterChangedPop;

        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))//check the Tile dictionary for tile with string "pos" exist
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; // Tile exists place in variable t

            if (t.name == pos)
            {
                //vi måste ta in objekten från listan, kolla vilken Tile*range familjen är på, antal av arten * foodNeeded variabeln för den familjen. Sen när det är klart
                //så måste vi uppdatera available food på den tilen * range

                if (t.meatOnTile >= animal.foodNeeded)
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hasEaten = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //increasing the population.
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //increasing the population.
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness++;
                }
                else
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        beforeChangedPop = animal.population;
                        animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                        afterChangedPop = animal.population;
                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                        //setting new vegetationOnTile if population rises
                        if (animal.hasEaten)
                        {
                            globalTiles.Find(x => x.name == pos).meatOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }


                        //maybe we should release the amount of meatOnTile as well? Complex question since if they only ate vegetation, releasing MeatOnTile will rocket. The same if it is the other way around...

                        if (animal.population <= 0)
                        {
                            return false;
                        }
                    }
                }
            }
        }
        Debug.Log("Number of shrews : " + ": " + Targetanimal.population);
        return true;
        return true;
    }


    bool update_weasel(WeaselInfo Targetanimal, double growth, double decrease)
    {

        Weasel animal = Targetanimal;
        string pos = Targetanimal.TilePosition;

        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        // take in the global vector that holds the herbivore coordinate

        int beforeChangedPop;
        int afterChangedPop;

        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))//check the Tile dictionary for tile with string "pos" exist
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; // Tile exists place in variable t

            if (t.name == pos)
            {
                //vi måste ta in objekten från listan, kolla vilken Tile*range familjen är på, antal av arten * foodNeeded variabeln för den familjen. Sen när det är klart
                //så måste vi uppdatera available food på den tilen * range

                if (t.meatOnTile >= animal.foodNeeded)
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hasEaten = true;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        if (animal.hungryYears > 1)
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //increasing the population.
                        }
                        else
                        {
                            animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //increasing the population.
                        }
                        animal.hungryYears = 0;
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                    Happiness++;
                }
                else
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if (animal.hungryYears >= 2)
                    {
                        beforeChangedPop = animal.population;
                        animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                        afterChangedPop = animal.population;
                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                        //setting new vegetationOnTile if population rises
                        if (animal.hasEaten)
                        {
                            globalTiles.Find(x => x.name == pos).meatOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                        }


                        //maybe we should release the amount of meatOnTile as well? Complex question since if they only ate vegetation, releasing MeatOnTile will rocket. The same if it is the other way around...

                        if (animal.population <= 0)
                        {
                            return false;
                        }
                    }
                }
            }
        }
        Debug.Log("Number of weasels : " + ": " + Targetanimal.population);
        return true;
    }
    bool update_fox(FoxInfo Targetanimal, double growth, double decrease)
    {
        Fox animal = Targetanimal;
        string pos = Targetanimal.TilePosition;

        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        // take in the global vector that holds the herbivore coordinate

        int beforeChangedPop;
        int afterChangedPop;

        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))//check the Tile dictionary for tile with string "pos" exist
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; // Tile exists place in variable t

            if (t.meatOnTile >= animal.foodNeeded)
            {
                //vi sätter familjens/artens satisfiedyears counter
                animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                animal.hasEaten = true;
                if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                {
                    beforeChangedPop = animal.population;
                    if (animal.hungryYears > 1)
                    {
                        animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //increasing the population.
                    }
                    else
                    {
                        animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //increasing the population.
                    }
                    animal.hungryYears = 0;
                    afterChangedPop = animal.population;

                    //setting new meatOnTile level if population rises
                    globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                    //setting new vegetationOnTile if population rises
                    globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                }
                Happiness++;
            }
            else
            {
                animal.satisfiedYears = 0;
                animal.hungryYears++;
                if (animal.hungryYears >= 2)
                {
                    beforeChangedPop = animal.population;
                    animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                    afterChangedPop = animal.population;
                    //setting new meatOnTile level if population rises
                    globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                    //setting new vegetationOnTile if population rises
                    if (animal.hasEaten)
                    {
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                    }


                    //maybe we should release the amount of meatOnTile as well? Complex question since if they only ate vegetation, releasing MeatOnTile will rocket. The same if it is the other way around...

                    if (animal.population <= 0)
                    {
                        return false;
                    }
                }
            }
        }

        Debug.Log("Number of foxes : " + ": " + Targetanimal.population);
        return true;
    }
    bool update_wolf(WolfInfo Targetanimal, double growth, double decrease)
    {
        Wolf animal = Targetanimal;
        string pos = Targetanimal.TilePosition;

        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        // take in the global vector that holds the herbivore coordinate

        int beforeChangedPop;
        int afterChangedPop;

        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))//check the Tile dictionary for tile with string "pos" exist
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; // Tile exists place in variable t

            if (t.meatOnTile >= animal.foodNeeded)
            {
                //vi sätter familjens/artens satisfiedyears counter
                animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                animal.hasEaten = true;
                if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                {
                    beforeChangedPop = animal.population;
                    if (animal.hungryYears > 1)
                    {
                        animal.population += (int)Math.Ceiling(beforeChangedPop * (growth / 2)); //increasing the population.
                    }
                    else
                    {
                        animal.population += (int)Math.Ceiling(beforeChangedPop * growth); //increasing the population.
                    }
                    animal.hungryYears = 0;
                    afterChangedPop = animal.population;

                    //setting new meatOnTile level if population rises
                    globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                    //setting new vegetationOnTile if population rises
                    globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                }
                Happiness++;
            }
            else
            {
                animal.satisfiedYears = 0;
                animal.hungryYears++;
                if (animal.hungryYears >= 2)
                {
                    beforeChangedPop = animal.population;
                    animal.population -= (int)Math.Ceiling(beforeChangedPop * decrease);
                    afterChangedPop = animal.population;
                    //setting new meatOnTile level if population rises
                    globalTiles.Find(x => x.name == pos).meatOnTile -= ((beforeChangedPop - afterChangedPop) * animal.meatValue);
                    //setting new vegetationOnTile if population rises
                    if (animal.hasEaten)
                    {
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((beforeChangedPop - afterChangedPop) * animal.foodNeeded);
                    }

                    //maybe we should release the amount of meatOnTile as well? Complex question since if they only ate vegetation, releasing MeatOnTile will rocket. The same if it is the other way around...

                    if (animal.population <= 0)
                    {
                        return false;
                    }
                }
            }
        }

        Debug.Log("Number of weasels : " + ": " + Targetanimal.population);
        return true;
    }


}










