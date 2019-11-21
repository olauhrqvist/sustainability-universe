using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RewardSystem : MonoBehaviour
{
    public float currency;

    public float TotalReward;
    public float AnimalTotalReward;
    public float TreeTotalReward;

    private GameObject MYgameObject;

    public List<TileClass> listan = new List<TileClass>();




    public void Calculate()
    {    
        listan = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().Getlist();
        NewCheck();

        foreach(TileClass i in listan)
        {
           CalculateHappines(i);
        }

         TotalReward = CaluclateTotalHappines(AnimalTotalReward, TreeTotalReward, listan.Count);

    }

    public void NewCheck()
    {
        TotalReward = 0f;
        AnimalTotalReward = 0f;
        TreeTotalReward = 0f;
    }

    public void CalculateHappines(TileClass i)
    {
        AnimalTotalReward += i.AnimalHappiness;
        TreeTotalReward += i.TreeHappiness;
    }

    public float CaluclateTotalHappines(float AnimalTotalReward, float TreeTotalReward,  int tileSize)
    {
        return ((AnimalTotalReward + TreeTotalReward) / (tileSize/2));
    }

    public void AddCurrency(float TotalReward)
    {
        currency = 1000f * TotalReward; //exempel
    }








}
