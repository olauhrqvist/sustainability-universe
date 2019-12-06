using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RewardSystem : MonoBehaviour
{
  public float currency = 100;

  public float TotalReward;
  public float AnimalTotalReward;
  public float TreeTotalReward;

  private GameObject MYgameObject;

  public List<TileClass> listan = new List<TileClass>();




  public void Calculate(int Happiness)
  {
    AddCurrency(Happiness);
  }
  public void AddCurrency(int Reward)
  {

    currency += 10f * (float)Reward;
   // print((float)Reward + "     " + currency);
  }








}
