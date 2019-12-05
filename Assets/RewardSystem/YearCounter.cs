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
  private float adder = 2f;

  public GameObject text;
  public GameObject yeartext;
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
            Counter += adder;
            print(Counter);
            other.Calculate();

            bw.YearUpdate();
            yeartext.GetComponent<Text>().text = "Year: " + Year;
            text.GetComponent<Text>().text = other.currency + " KR";

        }

        //------------------------------------------------------------------------------\\
    }
}
