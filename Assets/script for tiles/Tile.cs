using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Tile : MonoBehaviour
{

    protected Pair<int, int> id; //id will be the coordinate
    protected int[] neighbours;
    protected double pH;
    protected int moisture;
    protected int sunlight = 100;
    protected int nutrition;
    protected int freeSpace = 100;
    protected Tile groundType; //what for?
    //private Pair<bool, base_playable> tileHashType;

    public abstract void setPH(double change_val);
    public abstract double getPH();

    public abstract void setMoisture(int change_moi);
    public abstract int getMoisture();

    public abstract void setSunlight(int change_sun);
    public abstract int getSunlight();

    public abstract void setNutrition(int change_nut);
    public abstract int getNutrition();

    public abstract void setFreeSpace(int change_spa);
    public abstract int getFreeSpace();

    public abstract Pair<int,int> getCoord(); //a function that returns the x and y values
    public abstract int[] getNeighbours(int[][] map);


}

public class Pair<T, U>
{
    public Pair()
    {
    }

    public Pair(T first, U second)
    {
        this.First = first;
        this.Second = second;
    }

    public T First { get; set; }
    public U Second { get; set; }
};