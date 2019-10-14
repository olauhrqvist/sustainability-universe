using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonPressed : GameState
{
  
    public void pauseButtonPressed()
    {
        if (Time.timeScale == 1)
        {
            Debug.Log("In pauseButtonPressed()");
            Time.timeScale = 0;
            Debug.Log("Before showPauseMenu()");
            showPauseMenu();
            Debug.Log("After showPauseMenu()");
        }
    }


}
