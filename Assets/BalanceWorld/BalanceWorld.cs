using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BalanceWorld : MonoBehaviour
{

    List<TileClass> globalTiles = new List<TileClass>();
   public static TileClass tile { get; set; }
   private Global_Database Databas;

    public void Start()
    {
    }


    public BalanceWorld()
    {
        //globalTiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
    }




    //we are hoping that tiles is what we want it to be.

 


    // Update is called once per year
    public void YearUpdate()
    {
        Databas = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().globalDatabase;
        globalTiles =  GameObject.Find("SpawnMap").GetComponent<SpawnMap>().Getlist();
    Debug.Log("We are in year info!");
        //gå igenom vectorn med djur och sätt ett meat värde på de tiles där djur finns.


        //List<...Info> ...List
        //...Info.Newobject
        //start with herbivores
        /*  foreach(MouseInfo m in MouseList)
          {
             update_herbivore(m.Newobject, m.TilePosition, 0.4, 0.35);
          }
 */        // setMeatlevelOnTile();

        foreach (HareInfo h in Databas.HareList)
        {
            update_hare(h.Newobject, h.TilePosition, 0.35, 0.25);
        }
        // setMeatlevelOnTile();
        /*   foreach(DeerInfo d in DeerList)
           {
              update_herbivore(d.Newobject, d.TilePosition, 0.25, 0.15);
           }
           //setMeatlevelOnTile();
           foreach(MooseInfo m in MooseList)
           {
              update_herbivore(m.Newobject, m.TilePosition, 0.15, 0.10);
           }
           //setMeatlevelOnTile();


           //Then continue with omnivores
           foreach(SquirrelInfo s in SquirrelList)
           {
              update_omnivore(s.Newobject, s.TilePosition, 0.4, 0.35);
           }
           //setMeatlevelOnTile();
           foreach(RatInfo r in RatList)
           {
              update_omnivore(r.Newobject, r.TilePosition, 0.35, 0.25);
           }
           //setMeatlevelOnTile();
           foreach(WildBoarInfo b in BoarList)
           {
              update_omnivore(b.Newobject, b.TilePosition, 0.25, 0.15);
           }
           //setMeatlevelOnTile();
           foreach(BrownBearInfo b in BrownBearList)
           {
              update_omnivore(b.Newobject, b.TilePosition, 0.15, 0.10);
           }*/
        // setMeatlevelOnTile();

        //finally go through the carnivores

       // print(Databas.ShrewList.Count);

        foreach (ShrewInfo s in Databas.ShrewList)
        {
         //   print("adbaluiaw");
            update_shrew(s.Newobject, s.TilePosition, 0.4, 0.35);
        }
        //setMeatlevelOnTile();
        /*   foreach(WeaselInfo w in WeaselList)
           {
              update_carnivore(w.Newobject, w.TilePosition, 0.35, 0.25);
           }*/
        //setMeatlevelOnTile();
        foreach (FoxInfo f in Databas.FoxList)
        {
            update_fox(f.Newobject, f.TilePosition, 0.25, 0.15);
        }
        //setMeatlevelOnTile();
        /*   foreach(WolfInfo w in WolfList)
           {
              update_carnivore(w.Newobject, w.TilePosition, 0.15, 0.10);
           }
          // setMeatlevelOnTile();
       }*/



        void update_hare(GameObject animal, string pos, double growth, double decrease)
        {
            //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
            // take in the global vector that holds the herbivore coordinate
            int h = GameObject.Find("Hare").GetComponent<Hare>().hungryYears;
            foreach (TileClass t in globalTiles)
            {
                if (t.name == pos)
                {
                    // check available food on that coordinate + adjacent coordinates within the range for that animal
                    //vi måste ta in objekten från listan, kolla vilken Tile*range familjen är på, antal av arten * foodNeeded variabeln för den familjen. Sen när det är klart
                    //så måste vi uppdatera available food på den tilen * range
                    if (t.vegetationOnTile >= GameObject.Find("Hare").GetComponent<Hare>().foodNeeded)
                    {
                        //vi sätter familjens/artens satisfiedyears counter
                        GameObject.Find("Hare").GetComponent<Hare>().satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                        GameObject.Find("Hare").GetComponent<Hare>().hungryYears = 0;
                        if (GameObject.Find("Hare").GetComponent<Hare>().satisfiedYears % 2 == 0) //if the animals have been satisfied for two years in a row then they will increase the population
                        {
                            int temp = GameObject.Find("Hare").GetComponent<Hare>().population;
                            GameObject.Find("Hare").GetComponent<Hare>().population += (int)Math.Ceiling(temp * growth);
                        }
                    }
                    else
                    {
                        GameObject.Find("Hare").GetComponent<Hare>().satisfiedYears = 0;
                        GameObject.Find("Hare").GetComponent<Hare>().hungryYears++;
                        if (GameObject.Find("Hare").GetComponent<Hare>().hungryYears >= 2)
                        {
                            int temp = GameObject.Find("Hare").GetComponent<Hare>().population;
                            GameObject.Find("Hare").GetComponent<Hare>().population -= (int)Math.Ceiling(temp * decrease);
                        }
                    }
                }
            }
        }

        /*
        void update_omnivore(GameObject animal, string pos, double growth, double decrease)
        {
                //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        //take in the global vector that holds the herbivore coordinate

             //   check available food on that coordinate + adjacent coordinates within the range for that animal
                if(tile.availableFood >= animal.neededFood)
                {
                    animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                    animal.hungryYears = 0;
                    if(animal.satisfiedYears % 2 == 0 ) //if the animals have been satisfied for two years in a row then they will increase the population
                    {
                        animal.population += Math.Ceiling(animal.Population * growth);
                    }
                }
                else if(tile.availableFood < animal.neededFood)
                {

                    if(tile.availableMeat >= animal.neededFood)
                    {            
                        animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                        animal.hungryYears = 0;
                        if(animal.satisfiedYears % 2 == 0 ) //if the animals have been satisfied for two years in a row then they will increase the population
                        {
                            animal.population += Math.Ceiling(animal.Population * growth);
                        }
                    }
                }
                else
                {
                    animal.satisfiedYears = 0;
                    animal.hungryYears++;
                    if(animal.hungryYears >=2)
                    {
                            animal.population -= Math.Ceiling(animal.Population * decrease);
                    }  
                }



        }


                void update_carnivore(GameObject animal, string pos, double growth, double decrease)
            {

                //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
               // take in the global vector that holds the herbivore coordinate


                   // check available food on that coordinate + adjacent coordinates within the range for that animal
                    if(tile.availableMeat >= animal.neededFood)
                    {
                        animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                        animal.hungryYears = 0;
                        if(animal.satisfiedYears % 2 == 0 ) //if the animals have been satisfied for two years in a row then they will increase the population
                        {
                            animal.population += Math.Ceiling(animal.population * growth);
                        }
                    }
                    else
                    {
                        animal.satisfiedYears = 0;
                        animal.hungryYears++;
                        if(animal.hungryYears >=2)
                        {
                            animal.population -= Math.Ceiling(animal.population * decrease);
                        }   
                    }
                  }*/
        void update_shrew(GameObject animal, string pos, double growth, double decrease)
        {
            //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
            // take in the global vector that holds the herbivore coordinate
            int h = GameObject.Find("Shrew").GetComponent<Shrew>().hungryYears;
            foreach (TileClass t in globalTiles)
            {
                if (t.name == pos)
                {
                    // check available food on that coordinate + adjacent coordinates within the range for that animal
                    //vi måste ta in objekten från listan, kolla vilken Tile*range familjen är på, antal av arten * foodNeeded variabeln för den familjen. Sen när det är klart
                    //så måste vi uppdatera available food på den tilen * range
                    if (t.vegetationOnTile >= GameObject.Find("Shrew").GetComponent<Shrew>().foodNeeded)
                    {
                        //vi sätter familjens/artens satisfiedyears counter
                        GameObject.Find("Shrew").GetComponent<Shrew>().satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                        GameObject.Find("Shrew").GetComponent<Shrew>().hungryYears = 0;
                        if (GameObject.Find("Shrew").GetComponent<Shrew>().satisfiedYears % 2 == 0) //if the animals have been satisfied for two years in a row then they will increase the population
                        {
                            int temp = GameObject.Find("Shrew").GetComponent<Shrew>().population;
                            GameObject.Find("Shrew").GetComponent<Shrew>().population += (int)Math.Ceiling(temp * growth);
                        }
                    }
                    else
                    {
                        GameObject.Find("Shrew").GetComponent<Shrew>().satisfiedYears = 0;
                        GameObject.Find("Shrew").GetComponent<Shrew>().hungryYears++;
                        if (GameObject.Find("Shrew").GetComponent<Shrew>().hungryYears >= 2)
                        {
                            int temp = GameObject.Find("Shrew").GetComponent<Shrew>().population;
                          //  GameObject.Find("Shrew").GetComponent<Shrew>().population -= (int)Math.Ceiling(temp * decrease);
                        }
                    }
                    Debug.Log("Number of shrews342452325: " + GameObject.Find("Shrew").GetComponent<Shrew>().population);
                    Debug.Log("Number of Years: " + GameObject.Find("Shrew").GetComponent<Shrew>().satisfiedYears);
                }
            }
            Debug.Log("Number of shrews2: " + GameObject.Find("Shrew").GetComponent<Shrew>().population);
            Debug.Log("Number of Years2: " + GameObject.Find("Shrew").GetComponent<Shrew>().satisfiedYears);
        }


        void update_fox(GameObject animal, string pos, double growth, double decrease)
        {
            //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
            // take in the global vector that holds the herbivore coordinate
            int h = GameObject.Find("Fox").GetComponent<Fox>().hungryYears;
            foreach (TileClass t in globalTiles)
            {
                if (t.name == pos)
                {
                    // check available food on that coordinate + adjacent coordinates within the range for that animal
                    //vi måste ta in objekten från listan, kolla vilken Tile*range familjen är på, antal av arten * foodNeeded variabeln för den familjen. Sen när det är klart
                    //så måste vi uppdatera available food på den tilen * range
                    if (t.vegetationOnTile >= GameObject.Find("Fox").GetComponent<Fox>().foodNeeded)
                    {
                        //vi sätter familjens/artens satisfiedyears counter
                        GameObject.Find("Fox").GetComponent<Fox>().satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                        GameObject.Find("Fox").GetComponent<Fox>().hungryYears = 0;
                        if (GameObject.Find("Fox").GetComponent<Fox>().satisfiedYears % 2 == 0) //if the animals have been satisfied for two years in a row then they will increase the population
                        {
                            int temp = GameObject.Find("Fox").GetComponent<Fox>().population;
                            GameObject.Find("Fox").GetComponent<Fox>().population += (int)Math.Ceiling(temp * growth);
                        }
                    }
                    else
                    {
                        GameObject.Find("Fox").GetComponent<Fox>().satisfiedYears = 0;
                        GameObject.Find("Fox").GetComponent<Fox>().hungryYears++;
                        if (GameObject.Find("Fox").GetComponent<Fox>().hungryYears >= 2)
                        {
                            int temp = GameObject.Find("Fox").GetComponent<Fox>().population;
                            GameObject.Find("Fox").GetComponent<Fox>().population -= (int)Math.Ceiling(temp * decrease);
                        }
                    }
                }
            }
        }


    }
}


    


