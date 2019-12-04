using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RewardSystem : MonoBehaviour
{
  public float currency = 100;

  public int TotalReward;
  private GameObject MYgameObject;

  public List<TileClass> listan = new List<TileClass>();




  public void Calculate(int Happiness)
  {
    AddCurrency(Happiness);
  }

  public void AddCurrency(int Happy)
  {
    currency += 10 * (float)Happy; //exempel
    print(currency + "   " + Happy);
  }








}
