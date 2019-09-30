using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Button : GameState
{
  public void NextScene(){
    SceneManager.LoadScene((int)SceneNr.Pause);
  }
}
