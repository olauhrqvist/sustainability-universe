using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneNr { Menu, Test1, Pause}

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

        SceneManager.LoadScene((int)SceneNr.Test1);
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

    /* Idea Section for save game
     
        When you start a new game, every possible variable for animals and vegetaion will be set to null on each tile. This will
        be saved in a 2 dimensional array or (vector if it exists) where arr[tile][variables on tile] 
        for each arr[tile] set variables to null except the init variables.

        When we're saving the game, we'll loop through each tile and set the variables for respective tile in a file.

        When we're loading a game, we'll open the file and put the variables for each tile in the array. We can use a key word
        in the file to know when we're at a new tile etc

        savefile.txt
        .
        .
        oak 1
        goose 3
        .
        .
        newTile //here we'll now that the tile is done, and we'll load arr[tile+1][] ...
      
      
      
     */



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
