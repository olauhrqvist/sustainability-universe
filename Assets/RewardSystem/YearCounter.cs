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
  private float Counter = 1f;
  private float adder = 1f;
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
            List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
            // add another tree on the tiles
            foreach (var tile in tiles)
            {
                if (tile.grow)
                {
                  tile.expand = true;
                  tile.spreadTrees();
                }
            }

            if (Bw.Happiness >= 10 && !HasTriggered)
            {
                ns.OverallHappiness(10);
                HasTriggered = true;
            }
            if (Year%100==0 && Year != 0)
            {
                ns.TimePassed(Year);
            }
        }
    }
}
