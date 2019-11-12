using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RewardSystem : MonoBehaviour
{
    public int currency;
    
    
    private float TotalReward;
    private float AnimalTotalReward;
    private float TreeTotalReward;

    private GameObject MYgameObject;
    //private List<int> HappinessList = new List<int>();



    void Start()
    {
        NewCheck();
        MYgameObject = this.gameObject;
        SpawnMap SM = MYgameObject.GetComponent<SpawnMap>();
        
        foreach(TileClass i in SM.Getlist())
        {
           CalculateHappines(i);
        }

         TotalReward = CaluclateTotalHappines(AnimalTotalReward, TreeTotalReward, SM.Getlist().Count);


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
