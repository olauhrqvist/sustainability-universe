using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public enum SceneNr { Menu, Game, Pause }

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        //framerate for the menu
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 3;
    }

    public void NewGame()
    {
        
        SceneManager.LoadScene((int)SceneNr.Test1);
        //set all variables
        //call function gameInit(); which will initialize a new game.
        //begin the game. call function gameMode().
    }

  
   public void QuitGame()
    {
        Application.Quit();
    }
}
