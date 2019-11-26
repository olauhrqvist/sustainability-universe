﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YearCounter : MonoBehaviour
{
   //script
    public RewardSystem other;
    public Global_Database Database;

    //variable

    private int Year = 0;
    private float Counter = 10f;

    //------------------------------------------------------------------------------\\

    public void Update()
    {

        if (Time.time >= Counter)
        {
            Year = Year + 1;
            Counter += Counter;          
            other.Calculate();
        }
    }
}