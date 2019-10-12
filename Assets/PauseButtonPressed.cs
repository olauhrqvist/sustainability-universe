using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonPressed : GameState
{
  
    public void pauseButtonPressed()
    {
        Time.timeScale = 0;
        showPauseMenu();
    }


}
