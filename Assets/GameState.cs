using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneNr { Menu, Game, Pause}

public class GameState : MonoBehaviour
{

   // private bool escPressed = false;
   // private int inc = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void ResumeGame()
    {

        SceneManager.LoadScene((int)SceneNr.Game);
        //we want to resume the "global" clock which we paused in PauseGame();

    }
    public void EndGame()
    {
        SceneManager.LoadScene((int)SceneNr.Menu);
    }
    public void PauseGame()
    {
        //we want to paus the "global" clock that runs the game.
        SceneManager.LoadScene((int)SceneNr.Pause);
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (!escPressed)
        {*/
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();   

            }
         
    }
}
