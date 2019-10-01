using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Button : GameState
{
  public void PauseGame(){
    SceneManager.LoadScene((int)SceneNr.Pause);
  }
}
