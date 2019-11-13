using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RewardSystem : MonoBehaviour
{
    public int currency;


    public float TotalReward;
    public float AnimalTotalReward;
    public float TreeTotalReward;

    private GameObject MYgameObject;

    public List<TileClass> listan = new List<TileClass>();



    public void Calculate()
    {
        //MYgameObject = this.gameObject;
        //SpawnMap SM = MYgameObject.GetComponent<SpawnMap>();

        NewCheck();
        Debug.Log("INNE I REWARD");
        listan = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().Getlist();


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
        return ((AnimalTotalReward + TreeTotalReward) / tileSize);
    }









}
