using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeExpansion : MonoBehaviour
{
    private GameObject treeObject;
    //private List<GameObject> tileMap;
    private GameObject tile;
    private Vector3 treePosition;
    private bool finished = false;
    public int maxDensity = 3;
    public int currentDensity = 0;

    // Start is called before the first frame update
    void Start()
    {
        treeObject = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().treeObject;
        
        // Calls function treeGrowth once every 3 seconds, starting at 0 seconds.
        //InvokeRepeating("Test", 0, 3f);



    }

    // Update is called once per frame
    void Update()
    {
        /*finished = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().finished;
        if (finished)
        {
            GameObject tile = GameObject.Find("23");
            Instantiate(treeObject, tile.transform.position, transform.rotation);
        }*/

    }

    void Test()
    {
        Debug.Log("Testing...");
    }

    void treeGrowth(GameObject tile)
    {
        /*
        
        // 

        // Set tree scale to 50% at first

        // Calculate the positions available, start with 1 and increase until maxDensity is reached.
        for (int i = 0; i < maxDensity; i++)
        {
            tile.destroyTrees();
            tile.calculatePositions(i);
            tile.placeTrees();
            currentDensity = i;
        }

        // If maxDensity is reached, start to increase scale 10% at each run.
        if (currentDensity == maxDensity)
        {
            // Increase scale of every tree
        }

        // When maxDensity is reached, start treeGrowth on surrounding tiles and start expanding the size. One at each run.
        foreach (var neighbour in tile.neighbours)
        {
            GameObject neighbour = GameObject.Find(neighbour.ToString());
            treeGrowth(neighbour);
        }
        */
        




    }
}

