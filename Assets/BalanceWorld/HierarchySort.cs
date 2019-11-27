using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Not in use since we don't have the time to implement it correctly


public class HierarchySort : Global_Database
{
    public List<GameObject> SortCarnivores(List<GameObject> InputObject)
    {

        List<GameObject> sorted = new List<GameObject>();

        //if the list is empty, then return a empty list.
        if(InputObject.Count == 0)
        {
            return sorted;
        }

        //if we are here then the list wasn't empty. Start the sort

        foreach (GameObject g in InputObject)
        {

            //loop through the container according to the hierarchy attribute in each carnivore/herbivore...class

        }

        return sorted;



    }


 
}
