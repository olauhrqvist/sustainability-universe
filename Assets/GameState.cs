using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneNr { Menu, Test1}

public class GameState : MonoBehaviour
{
    public GameObject[] pauseObjects;
    public bool game_paused = false;

    // Start is called before the first frame update
    void Start()
    {
        //setting the framrate and vsync
        Application.targetFrameRate = 200;
        QualitySettings.vSyncCount = 3;

        Time.timeScale = 1; //setting the timescale to 1 == game running
        pauseObjects = GameObject.FindGameObjectsWithTag("PauseMenu");
        hidePauseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        //if esc is pressed, call pauseAction()
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseAction();
        }
    }

    public void pauseAction()
    {
        //if game isn't paused, set timescale to 0. If game is paused, then unpause by setting timescale to 1
        Debug.Log(Time.timeScale);
        if (!game_paused)
        {
           
            Time.timeScale = 0;
            showPauseMenu();
            game_paused = true;

        }
        else if (game_paused)
        {
            Time.timeScale = 1;
            hidePauseMenu();
            game_paused = false;
        }
    }
    public void showPauseMenu()
    {

        foreach (GameObject g in pauseObjects)
        {
            Debug.Log("In foreach loop in showPauseMenu()");
            g.SetActive(true);
        }

    }


    public void hidePauseMenu()
    {

        foreach (GameObject g in pauseObjects)
        {
 
            if(g.name != "PauseButton")
                 g.SetActive(false);

        }
    }
    public void EndGame()
    {
        SceneManager.LoadScene((int)SceneNr.Menu);
    }



    public void resumeButtonPressed2()
    {
        Time.timeScale = 1;
        hidePauseMenu();
        game_paused = false;
    }

    public void pauseButtonPressed2()
    {
        Time.timeScale = 0;
        showPauseMenu();
        game_paused = true;
    }

}
