using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceWorld : MonoBehaviour
{
   
    // Update is called once per year
   public void YearUpdate()
    {
        //    gameobject animal;
        /*
          
        //gå igenom vectorn med djur och sätt ett meat värde på de tiles där djur finns.
        setMeatlevelOnTile();
         
         update_herbivore(mouse, 0.4, 0.35);
         update_herbivore(rabbit, 0.35, 0.25);
         update_herbivore(deer, 0.25, 0.15);
         update_herbivore(moose, 0.15, 0.10);

        update_omnivore(squirell, 0.4, 0.35);
        update_omnivore(rat, 0.35, 0.25);
        update_omnivore(wildHog, 0.25, 0.15);
        update_omnivore(bear, 0.15, 0.10);

        update_carnivore(shrew, 0.4, 0.35);
        update_carnivore(veesel, 0.35, 0.25);
        update_carnivore(fox, 0.25, 0.15);
        update_carnivore(wolf, 0.15, 0.10);
        */
     }


    /*                
    void update_herbivore(gameobject animal, double growth, double decrease)
    {

        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        take in the global vector that holds the herbivore coordinate

        for each object in that vector
        {
            check available food on that coordinate + adjacent coordinates within the range for that animal
            if(tile.availableFood >= animal.neededFood)
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
                    animal.population -= Math.Ceiling(animal.Population * decrease)
                }   
            }
          }
     }
            */

    /*
void update_omnivore(gameobject animal, double growth, double decrease)
{
        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
take in the global vector that holds the herbivore coordinate
    for each object in that vector
    {
        check available food on that coordinate + adjacent coordinates within the range for that animal
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
                animal.population -= Math.Ceiling(animal.Population * decrease)
            }  
        }

    }

}
*/

    /*
   
        void update_carnivore(gameobject animal, double growth, double decrease)
    {

        //we will let the animals eat in their hierarchical order from smallest to the biggest. If the food is gone when the moose wants to eat, tough luck for the moose...
        take in the global vector that holds the herbivore coordinate

        for each object in that vector
        {
            check available food on that coordinate + adjacent coordinates within the range for that animal
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
                    animal.population -= Math.Ceiling(animal.Population * decrease)
                }   
            }
          }
     }












    */
}
