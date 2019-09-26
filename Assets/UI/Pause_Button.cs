using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Button : MonoBehaviour
{
  public void NextScene(){
    SceneManager.LoadScene((int)SceneNr.Pause);
  }
}
