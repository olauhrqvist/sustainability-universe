using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YearCounter : MonoBehaviour
{
   //script
    public RewardSystem other;
    public Global_Database Database;
    public BalanceWorld bw;

    //variable

    private int Year = 0;
    private float Counter = 2f;
    private float YearsCounter = 2f;

    public GameObject text;

    //------------------------------------------------------------------------------\\
   public void Start()
    {
        other.currency = 100;
        text.GetComponent<Text>().text = other.currency + " KR";
        //rewardsystem = GameObject.Find("SpawnMap").GetComponent<RewardSystem>();
    }
    public void Update()
    {
       
        if (Time.time >= Counter)
        {
            Year = Year + 1;
            Counter += YearsCounter;          
            other.Calculate();

            bw.YearUpdate();

            text.GetComponent<Text>().text = other.currency + " KR";
        }

    }
}
