using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Script : Vegetation
{
    public Tree_Script(
                                int hierarchy,
                                int ID,
                                GameObject mesh,
                                int range,
                                int space,
                                Dictionary<string, double> enviroment,
                                int forestid,
                                int growthtime,
                                string species,
                                int SunlightCost,
                                int NutritionalCost) : base(
                                                    "Tree", // type = tree
                                                    0, //hierarchy =0 ? not sure if it's 0 
                                                    ID, // what is ID for a tree ?
                                                    mesh, //?
                                                    1, // range = 1 tile
                                                    10, // space = 10 ? 
                                                    enviroment,//?
                                                    forestid, // set in tile script
                                                    growthtime, // dynamic or fixed? if fixed value, set here.
                                                    species, // name of tree? set in tile script
                                                    SunlightCost, //ignore 
                                                    NutritionalCost)  // not sure, each tree cost the same ? or based on species?
    {

    }
}
