﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BalanceWorld : MonoBehaviour
{

    List<TileClass> globalTiles = new List<TileClass>();
    public static TileClass tile { get; set; }
    private Global_Database Databas;


    public BalanceWorld()
    {
        //globalTiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
    }




    //we are hoping that tiles is what we want it to be.




    // Update is called once per year
    public void YearUpdate()
    {

        Databas = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().globalDatabase;
        globalTiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().Getlist();

        //gå igenom vectorn med djur och sätt ett meat värde på de tiles där djur finns.


        //List<...Info> ...List
        //...Info.Newobject
        //start with herbivores
        foreach (MouseInfo m in Databas.MouseList)
        {
            update_mouse(m, 0.4, 0.35);
        }


        foreach (HareInfo h in Databas.HareList)
        {
            update_hare(h, 0.35, 0.25);
        }

        foreach (DeerInfo d in Databas.DeerList)
        {
            update_deer(d, 0.25, 0.15);
        }

        foreach (MooseInfo m in Databas.MooseList)
        {
            update_moose(m, 0.15, 0.10);
        }


        //Then continue with omnivores
        foreach (SquirrelInfo s in Databas.SquirrelList)
        {
            update_squirell(s, 0.4, 0.35);
        }

        foreach (RatInfo r in Databas.RatList)
        {
            update_rat(r, 0.35, 0.25);
        }
        foreach (WildBoarInfo b in Databas.BoarList)
        {
            update_boar(b, 0.25, 0.15);
        }

        foreach (BrownBearInfo b in Databas.BrownBearList)
        {
            update_brownBear(b, 0.15, 0.10);
        }


        //finally go through the carnivores


        foreach (ShrewInfo s in Databas.ShrewList)
        {

            //  update_shrew(s.TilePosition, 0.4, 0.35);


            update_shrew(s, 0.4, 0.35); // throws in the whole array element (s) into the function

        }

        foreach (WeaselInfo w in Databas.WeaselList)
        {
            update_weasel(w, 0.35, 0.25);
        }

        foreach (FoxInfo f in Databas.FoxList)
        {
            update_fox(f, 0.25, 0.15);
        }

        foreach (WolfInfo w in Databas.WolfList)
        {
            update_wolf(w, 0.15, 0.10);
        }

    }

    void update_mouse(MouseInfo Targetanimal, double growth, double decrease)
    {
        Mouse animal = Targetanimal;
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
                    animal.hungryYears = 0;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
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
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile += ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);

                        if (animal.population <= 0)
                        {
                            //call a destructor for the animal
                        }
                    }
                }

            }
        }
    }

    void update_hare(HareInfo Targetanimal, double growth, double decrease)
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
                    animal.hungryYears = 0;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        afterChangedPop = animal.population;

                       
                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                        Debug.Log("Hares, meatOnTile from the hares______________________________________: " + globalTiles.Find(x => x.name == pos).meatOnTile);
                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                        Debug.Log("Hares, vegetationOnTile from the hares______________________________________: " + globalTiles.Find(x => x.name == pos).vegetationOnTile);
                    }
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
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile += ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);

                        if (animal.population <= 0)
                        {
                            //call a destructor for the animal
                        }
                    }
                }

            }
        }
        Debug.Log("Number of hares______________________________________: " + animal.population);
        Debug.Log("Number of satisifedYears______________________________: " + animal.satisfiedYears);
        Debug.Log("Number of hungryYears_________________________________: " + animal.hungryYears);
    }

    void update_deer(DeerInfo Targetanimal, double growth, double decrease)
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
                    animal.hungryYears = 0;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
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
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile += ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);

                        if (animal.population <= 0)
                        {
                            //call a destructor for the animal
                        }
                    }
                }

            }
        }
    }

    void update_moose(MooseInfo Targetanimal, double growth, double decrease)
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
                    animal.hungryYears = 0;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
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
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile += ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);

                        if (animal.population <= 0)
                        {
                            //call a destructor for the animal
                        }
                    }
                }

            }
        }
    }

    void update_squirell(SquirrelInfo Targetanimal, double growth, double decrease)
    {
        Squirrel animal = Targetanimal;
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
                    animal.hungryYears = 0;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                }
                else if (t.meatOnTile >= animal.foodNeeded) //if there is no vegetation left, eat meat
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hungryYears = 0;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
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
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile += ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);

                        //maybe we should release the amount of meatOnTile as well? Complex question since if they only ate vegetation, releasing MeatOnTile will rocket. The same if it is the other way around...

                        if (animal.population <= 0)
                        {
                            //call a destructor for the animal
                        }
                    }

                }

            }
        }
    }

    void update_rat(RatInfo Targetanimal, double growth, double decrease)
    {
        Rat animal = Targetanimal;
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
                    animal.hungryYears = 0;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                }
                else if (t.meatOnTile >= animal.foodNeeded) //if there is no vegetation left, eat meat
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hungryYears = 0;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
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
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile += ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);

                        //maybe we should release the amount of meatOnTile as well? Complex question since if they only ate vegetation, releasing MeatOnTile will rocket. The same if it is the other way around...


                        if (animal.population <= 0)
                        {
                            //call a destructor for the animal
                        }
                    }

                }

            }
        }
    }
    void update_boar(WildBoarInfo Targetanimal, double growth, double decrease)
    {

        Boar animal = Targetanimal;
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
                    animal.hungryYears = 0;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                }
                else if (t.meatOnTile >= animal.foodNeeded) //if there is no vegetation left, eat meat
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hungryYears = 0;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
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
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile += ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);

                        //maybe we should release the amount of meatOnTile as well? Complex question since if they only ate vegetation, releasing MeatOnTile will rocket. The same if it is the other way around...

                        if (animal.population <= 0)
                        {
                            //call a destructor for the animal
                        }
                    }

                }

            }
        }
    }
    void update_brownBear(BrownBearInfo Targetanimal, double growth, double decrease)
    {

        BrownBear animal = Targetanimal;
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
                    animal.hungryYears = 0;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
                }
                else if (t.meatOnTile >= animal.foodNeeded) //if there is no vegetation left, eat meat
                {
                    //vi sätter familjens/artens satisfiedyears counter
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hungryYears = 0;
                    if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        beforeChangedPop = animal.population;
                        animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                        afterChangedPop = animal.population;

                        //setting new meatOnTile level if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                    }
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
                        globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                        //setting new vegetationOnTile if population rises
                        globalTiles.Find(x => x.name == pos).vegetationOnTile += ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);


                        //maybe we should release the amount of meatOnTile as well? Complex question since if they only ate vegetation, releasing MeatOnTile will rocket. The same if it is the other way around...

                        if (animal.population <= 0)
                        {
                            //call a destructor for the animal
                        }
                    }

                }

            }
        }
    }

    /* void update_shrew(string pos, double growth, double decrease)
         {


             Shrew animal = GameObject.Find("Shrew").GetComponent<Shrew>();

         //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
         // take in the global vector that holds the herbivore coordinate
         //   int h = animal.hungryYears;
         foreach (TileClass t in globalTiles)
         {
             if (t.name == pos)
             {
                 //vi måste ta in objekten från listan, kolla vilken Tile*range familjen är på, antal av arten * foodNeeded variabeln för den familjen. Sen när det är klart
                 //så måste vi uppdatera available food på den tilen * range
                 int beforeChangedPop;
                 int afterChangedPop;
                 if (t.meatOnTile >= animal.foodNeeded)
                 {
                     //vi sätter familjens/artens satisfiedyears counter
                     animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                     animal.hungryYears = 0;


                   }*/
    void update_shrew(ShrewInfo Targetanimal, double growth, double decrease)
    {
        Shrew animal = Targetanimal;
        string pos = Targetanimal.TilePosition;

        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        // take in the global vector that holds the herbivore coordinate
        //   int h = animal.hungryYears;
        /*foreach (TileClass t in globalTiles)
        {*/
        int beforeChangedPop;
        int afterChangedPop;

        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))//check the Tile dictionary for tile with string "pos" exist
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; // Tile exists place in variable t

            if (t.meatOnTile >= animal.foodNeeded)
            {
                animal.satisfiedYears++;
                animal.hungryYears = 0;

                if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                {
                    beforeChangedPop = animal.population;
                    animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                    afterChangedPop = animal.population;

                    //setting new meatOnTile level if population rises
                    globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                    //setting new vegetationOnTile if population rises
                    globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                }
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
                    //setting new meatOnTile level if population rises (lessen the food the dead anmimal gave)
                    globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                    //setting new meatOnTile if population rises (releasing the food they ate)
                    globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);

                    if (animal.population <= 0)
                    {
                        //call a destructor for the animal
                    }
                }
            }

        }


        Debug.Log("Number of shrews______________________________________: " + animal.population);
        Debug.Log("Number of satisifedYears______________________________: " + animal.satisfiedYears);
        Debug.Log("Number of hungryYears_________________________________: " + animal.hungryYears);
    }




    void update_weasel(WeaselInfo Targetanimal, double growth, double decrease)
    {

        Weasel animal = Targetanimal;
        string pos = Targetanimal.TilePosition;

        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        // take in the global vector that holds the herbivore coordinate
        //   int h = animal.hungryYears;

        int beforeChangedPop;
        int afterChangedPop;

        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))//check the Tile dictionary for tile with string "pos" exist
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; // Tile exists place in variable t

            if (t.meatOnTile >= animal.foodNeeded)
            {
                animal.satisfiedYears++;
                animal.hungryYears = 0;

                if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                {
                    beforeChangedPop = animal.population;
                    animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                    afterChangedPop = animal.population;

                    //setting new meatOnTile level if population rises
                    globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                    //setting new vegetationOnTile if population rises
                    globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                }
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
                    //setting new meatOnTile level if population rises (lessen the food the dead anmimal gave)
                    globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                    //setting new meatOnTile if population rises (releasing the food they ate)
                    globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);

                    if (animal.population <= 0)
                    {
                        //call a destructor for the animal
                    }
                }
            }

        }

    }

    void update_fox(FoxInfo Targetanimal, double growth, double decrease)
    {
        Fox animal = Targetanimal;
        string pos = Targetanimal.TilePosition;



        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        // take in the global vector that holds the herbivore coordinate
        //   int h = animal.hungryYears;
        int beforeChangedPop;
        int afterChangedPop;

        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))//check the Tile dictionary for tile with string "pos" exist
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; // Tile exists place in variable t

            if (t.meatOnTile >= animal.foodNeeded)
            {
                animal.satisfiedYears++;
                animal.hungryYears = 0;

                if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                {
                    beforeChangedPop = animal.population;
                    animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                    afterChangedPop = animal.population;

                    //setting new meatOnTile level if population rises
                    globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                    //setting new vegetationOnTile if population rises
                    globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                }
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
                    //setting new meatOnTile level if population rises (lessen the food the dead anmimal gave)
                    globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                    //setting new meatOnTile if population rises (releasing the food they ate)
                    globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);

                    if (animal.population <= 0)
                    {
                        //call a destructor for the animal
                    }
                }
            }

        }

    }

    void update_wolf(WolfInfo Targetanimal, double growth, double decrease)
    {


        Wolf animal = Targetanimal;
        string pos = Targetanimal.TilePosition;



        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        // take in the global vector that holds the herbivore coordinate
        //   int h = animal.hungryYears;
        int beforeChangedPop;
        int afterChangedPop;

        if (GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict.ContainsKey(pos))//check the Tile dictionary for tile with string "pos" exist
        {
            TileClass t = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().TileDict[pos]; // Tile exists place in variable t

            if (t.meatOnTile >= animal.foodNeeded)
            {
                animal.satisfiedYears++;
                animal.hungryYears = 0;

                if (animal.satisfiedYears % 2 == 0 && animal.satisfiedYears > 0) //if the animals have been satisfied for two years in a row then they will increase the population
                {
                    beforeChangedPop = animal.population;
                    animal.population += (int)Math.Ceiling(beforeChangedPop * growth);
                    afterChangedPop = animal.population;

                    //setting new meatOnTile level if population rises
                    globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.meatValue);

                    //setting new vegetationOnTile if population rises
                    globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);
                }
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
                    //setting new meatOnTile level if population rises (lessen the food the dead anmimal gave)
                    globalTiles.Find(x => x.name == pos).meatOnTile -= ((afterChangedPop - beforeChangedPop) * animal.meatValue);
                    //setting new meatOnTile if population rises (releasing the food they ate)
                    globalTiles.Find(x => x.name == pos).meatOnTile += ((afterChangedPop - beforeChangedPop) * animal.foodNeeded);

                    if (animal.population <= 0)
                    {
                        //call a destructor for the animal
                    }
                }
            }

        }

    }
}
           






    


