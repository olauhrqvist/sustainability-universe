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
  private float Counter = 10f;
  private float adder = 10f;

  public GameObject text;

  //------------------------------------------------------------------------------\\
  public void Start()
  {
    other.currency = 1000;
    text.GetComponent<Text>().text = other.currency + " KR";
    //rewardsystem = GameObject.Find("SpawnMap").GetComponent<RewardSystem>();
  }
  public void Update()
  {

    if (Time.time >= Counter)
    {
      Year = Year + 1;
      Counter += adder; ;
      other.Calculate(bw.Happiness);

      bw.YearUpdate();

      text.GetComponent<Text>().text = other.currency + " KR";

    }

    //------------------------------------------------------------------------------\\
  }
}
