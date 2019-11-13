using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YearCounter : MonoBehaviour
{
    //public GameObject RewardObject;
    public RewardSystem other;


    //variable

    private int Year = 0;
    private float Counter = 10f;





    //------------------------------------------------------------------------------\\

    public void Update()
    {

        if (Time.time >= Counter)
        {
            Debug.Log(Counter);
            Debug.Log(Year);
            Year = Year + 1;
            Counter += Counter;
            other.Calculate();
          //Debug.Log(other.TotalReward);

        }
    }

}
