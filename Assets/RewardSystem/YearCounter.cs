using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

/*
This is the YearCounter, This script keeps track of all year-related instances such as Rewards, BalanceWorld, tree growth.
*/

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

  private bool HasTriggered = false;


  public GameObject text;
  public GameObject yeartext;


  public void Start()
  {
    other.currency = 50;
    text.GetComponent<Text>().text = other.currency + " KR";
    yeartext.GetComponent<Text>().text = "Year: " + Year;

  }
  public void Update()
  {
    if (Application.isPlaying) //checks if the game is paused, if paused stop counting the timer. 
    {
      Timer += Time.deltaTime;
    }

    if (Timer >= Counter) //If Timer >= Counter than it means that it's a new year and all the calculations under need to be ran. 
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
      if (Year % 100 == 0 && Year != 0)
      {
        ns.TimePassed(Year);
      }
    }
  }
}
