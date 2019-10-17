﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BrownEarth : Tile
{
    public BrownEarth()
    {
        this.nutrition = 50; //change when we have the facts
        this.pH = 6.5;
        this.moisture = 30;
    }

    public override void setPH(double change_pH)
    {
        this.pH += change_pH;
    }
    public override double getPH()
    {
        return this.pH;
    }

   
    public override void setMoisture(int change_moi)
    {
        this.moisture += change_moi;
    }
    public override int getMoisture()
    {
        return this.moisture;
    }

    public override void setSunlight(int change_sun)
    {
        this.sunlight += change_sun;
    }
    public override int getSunlight()
    {
        return this.sunlight;
    }

    public override void setNutrition(int change_nut)
    {
        this.nutrition += change_nut;
    }
    public override int getNutrition()
    {
        return this.nutrition;
    }
    public override void setFreeSpace(int change_spa)
    {
        this.freeSpace += change_spa;
    }
    public override int getFreeSpace()
    {
        return this.freeSpace;
    }

    //a function that returns the x and y values
    public override Pair<int,int> getCoord()
    {
        return this.id;
    }
    public override int[] getNeighbours(int[][] map)
    {
        //needs to be implemented!
        int[] arr = new int[2];
        return arr;
    }

}









