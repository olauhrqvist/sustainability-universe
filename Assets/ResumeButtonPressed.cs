using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButtonPressed : GameState
{
    public bool run = false;


    public void resumeButtonPressed()
    {
        Time.timeScale = 1;
        if(run)
          hidePauseMenu();
    }

}
