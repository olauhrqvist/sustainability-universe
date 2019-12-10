using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButtonPressed : GameState
{

    public void resumeButtonPressed()
    {
        Time.timeScale = 1;
        hidePauseMenu();
    }

}
