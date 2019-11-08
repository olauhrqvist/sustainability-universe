using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pineTree
{

  // Variables
  public GameObject pineObject;

}




public class treeExpansion : MonoBehaviour
{
    private GameObject treeObject;
    //private List<GameObject> tileMap;
    private GameObject tile;
    private Vector3 treePosition;
    private bool finished = false;
    public int maxDensity = 3;
    public int currentDensity;
    private pineTree pine;
    private List<TileClass> tiles;
    // Start is called before the first frame update
    void Start()
    {

        //pine.pineObject = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().treeObject;
        //pine.pineObject.name = "pineTree";

        // Calls function treeGrowth once every 3 seconds, starting at 0 seconds.
        //InvokeRepeating("Test", 0, 3f);
        /*currentDensity = 2;

        finished = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().finished;
        if (finished)
        {
                  //Debug.Log("treePosition:" + pine.pineObject.transform.position.x + ", " + pine.pineObject.transform.position.y + "\n");
                  Debug.Log("Starting treeGrowth()");
                  InvokeRepeating("treeGrowth", 1, 3);
        }*/


        //InvokeRepeating("spread", 30, 3f);
        tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
        TileClass tile = tiles.Find(x => x.name == "23");
      //  tile.grow = true;


    }

    // Update is called once per frame
    void Update()
    {


    }


}
