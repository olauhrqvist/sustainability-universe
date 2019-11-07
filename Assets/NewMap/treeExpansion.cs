using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeExpansion : MonoBehaviour
{
    private GameObject treeObject;
    private GameObject tree;
    private List<GameObject> tileMap;
    private GameObject tile;
    private Vector3 treePosition;
    private bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        //treeObject = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().treeObject;
        //tileMap = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tileMap;


        
    }

    // Update is called once per frame
    void Update()
    {
        finished = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().finished;
        if (finished)
            treeGrowth();


    }


    void treeGrowth()
    {
        // At start, place single tree with 50% scale
        //tile = GameObject.Find("d3");
        //treeObject.transform.localscale -= new Vector3(0.5, 0.5, 0.5);
        //tree = Instantiate(treeObject, tile.transform.position, transform.rotation);



        // For every second, expand the tree


        // if currentDensity < maxDensity
        // increase density

        // else if currentDensity == maxDensity && currentScale < 100
        // increase scale each second

        // else
        // populate surrounding tiles
    }
}
