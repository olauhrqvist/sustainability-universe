﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class YearCounter : MonoBehaviour
{

    //script
    public RewardSystem other;
    public Global_Database Database;
    public BalanceWorld Bw;
    public NotificationScript ns;
    //variable

    private int Year = 0;
    private float Counter = 10f;
    private float adder = 10f;
    private float Timer = 0;
    public bool isPaused;
    private bool HasTriggered = false;

    public GameObject text;
    public GameObject yeartext;

    //public BalanceWorld Bw { get => bw; set => bw = value; }

    public void Start()
    {

        other.currency = 1000;
        text.GetComponent<Text>().text = other.currency + " KR";
        yeartext.GetComponent<Text>().text = "Year: " + Year;

    }
    public void Update()
    {
        if (Application.isPlaying)
        {
            Timer += Time.deltaTime;
        }

        if (Timer >= Counter)
        {
            Year += 1;
            Counter += adder;
            other.Calculate(Bw.Happiness);
            Bw.YearUpdate();
            text.GetComponent<Text>().text = other.currency + " KR";
            yeartext.GetComponent<Text>().text = "Year: " + Year;
            if(Bw.Happiness >= 100 || !HasTriggered)
            {
                ns.OverallHappiness(100);
                HasTriggered = true;
            }
            if (Year%10==0)
            {
                ns.TimePassed(Year);
            }
        }
    }
}
