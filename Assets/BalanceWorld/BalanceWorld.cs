using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceWorld : Global_Database
{
   public static TileClass tileClass { get; set; }

   Global_Database Something_tile = tileClass.globalDatabase;
    //we are hoping that tiles is what we want it to be.
    
    
    /*
    
    // Update is called once per year
    public void YearUpdate()
    {
           


    //gå igenom vectorn med djur och sätt ett meat värde på de tiles där djur finns.
       

        //start with herbivores
         foreach(Gameobject g in MouseList)
         {
            update_herbivore(g, 0.4, 0.35);
         }
         setMeatlevelOnTile();
          foreach(Gameobject g in HareList)
         {
            update_herbivore(g, 0.35, 0.25);
         }
         setMeatlevelOnTile();
         foreach(Gameobject g in RoeDeerList)
         {
            update_herbivore(g, 0.25, 0.15);
         }
         setMeatlevelOnTile();
         foreach(Gameobject g in MooseList)
         {
            update_herbivore(g, 0.15, 0.10);
         }
         setMeatlevelOnTile();
         
     
         //Then continue with omnivores
         foreach(Gameobject g in SquirrelList)
         {
            update_omnivore(g, 0.4, 0.35);
         }
         setMeatlevelOnTile();
         foreach(Gameobject g in RatList)
         {
            update_omnivore(g, 0.35, 0.25);
         }
         setMeatlevelOnTile();
         foreach(Gameobject g in BoarList)
         {
            update_omnivore(g, 0.25, 0.15);
         }
         setMeatlevelOnTile();
         foreach(Gameobject g in BrownBearList)
         {
            update_omnivore(, 0.15, 0.10);
         }
         setMeatlevelOnTile();

        //finally go through the carnivores
         foreach(Gameobject g in ShrewList)
         {
            update_carnivore(g, 0.4, 0.35);
         }
         setMeatlevelOnTile();
         foreach(Gameobject g in WeaselList)
         {
            update_carnivore(g, 0.35, 0.25);
         }
         setMeatlevelOnTile();
         foreach(Gameobject g in FoxList)
         {
            update_carnivore(g, 0.25, 0.15);
         }
         setMeatlevelOnTile();
         foreach(Gameobject g in WolfList)
         {
            update_carnivore(g, 0.15, 0.10);
         }
         setMeatlevelOnTile();

     }


                   
    void update_herbivore(GameObject animal, double growth, double decrease)
    {

        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
       // take in the global vector that holds the herbivore coordinate


    
           // check available food on that coordinate + adjacent coordinates within the range for that animal
           //vi måste ta in objekten från listan, kolla vilken Tile*range familjen är på, antal av arten * foodNeeded variabeln för den familjen. Sen när det är klart
           //så måste vi uppdatera available food på den tilen * range
            if(tile.availableFood >= animal.neededFood)
            {
            //vi sätter familjens/artens satisfiedyears counter
                animal.satisfiedYears++; //if they are unsatisfied one year this value will be set to zero.
                animal.hungryYears = 0;
                if(animal.satisfiedYears % 2 == 0 ) //if the animals have been satisfied for two years in a row then they will increase the population
                {
                    animal.population += Math.Ceiling(animal.Population * growth);
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
           

void update_omnivore(gameobject animal, double growth, double decrease)
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

   
        void update_carnivore(gameobject animal, double growth, double decrease)
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
                    animal.population += Math.Ceiling(animal.Population * growth);
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
     }

    */
}
