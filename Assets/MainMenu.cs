using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public enum SceneNr { Menu, Game, Pause }

public class MainMenu : MonoBehaviour
{
  
    public void NewGame()
    {
        SceneManager.LoadScene((int)SceneNr.Game);
        //set all variables
        //call function gameInit(); which will initialize a new game.
        //begin the game. call function gameMode().
    }
    public void LoadGame()
    {
      //string with load game name. the file to look for will be named in SaveGame()
      //when you have fetched the file, you will have to read the input variables and set them and then start the game with those variables
    }
   public void QuitGame()
    {
        Debug.Log("Quiting the hard game");
        Application.Quit();
    }
}
