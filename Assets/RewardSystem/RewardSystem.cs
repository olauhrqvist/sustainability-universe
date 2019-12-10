using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
A scripts that gives the player a reward each year based on happiness of the animalfamily on each tile. Happiess is calculated in
the BalanceWorld script.
*/
public class RewardSystem : MonoBehaviour
{
  public float currency = 100;

  public void Calculate(int Happiness)
  {
    AddCurrency(Happiness);
  }
  public void AddCurrency(int Reward)
  {
    currency += 10f * (float)Reward;
  }








}
