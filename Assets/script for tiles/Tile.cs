using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Tile : MonoBehaviour
{

    private int[][] id; //id will be the coordinate
    protected int[] neighbours;
    protected double pH;
    protected int moisture;
    protected int sunlight;
    protected int nutrition;
    protected int freeSpace;
    protected Tile groundType;
    //private Pair<bool, base_playable> tileHashType;


    protected Tile()
    {

        freeSpace = 100;

    }
    public abstract void setMoisture(int new_moisture);

    public int getMoisture() { return moisture; }
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