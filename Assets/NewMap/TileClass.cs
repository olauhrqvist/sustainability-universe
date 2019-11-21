using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClass : MonoBehaviour
{
    // Start is called before the first frame update

    //Variables for RewardSystem
    public float AnimalHappiness;
    public float TreeHappiness;
    public float TileHappiness;
    // Variables
    // Tile ID
    public string name;
    // Coordinate
    public int x;
    public int y;
    public bool grow;
    public bool growthDone;
    public bool spread;
    public bool expand;
    public bool tileFull;
    // Density
    public int natureDensity;
    public int currentDensity;
    // GameObject
    public GameObject tileGameObject;
    // Neighbours
    public List<string> neighbours;
    // Available positions
    private List<Pair> tilePositions;
    // Trees on tile
    public List<GameObject> tileTrees;

    // Pine tree GameObject

    public GameObject treeObject;
    //public GameObject pineGameObject;
    //public GameObject leafGameObject;
    // Methods
    bool pineForest;
    bool leafForest;
    public int forestID;


    public string Groundtype;



    // Constructor
    public TileClass()
    {
        int id = 0;
        int pH = 0;
        int Moisture = 100;
        int Nutrition = 100;
        int Space = 100;
        Groundtype = "";
        tilePositions = new List<Pair>();
        neighbours = new List<string>();
        tileTrees = new List<GameObject>();
        grow = false;
        currentDensity = 2;
        natureDensity = 3;
        growthDone = false;
        spread = false;
        expand = false;
        tileFull = false;
        pineForest = false;
        leafForest = false;
        forestID = -1;

    }
    public void markGroundtype()
    {

      foreach (var n in neighbours)
      {
        List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
        TileClass tile = tiles.Find(x => x.name == n);

        if(tile.Groundtype == "")
        {
          //Debug.Log(tile.name + " is now " + Groundtype);
          tile.Groundtype = Groundtype;
        }

      }

    }


    // Calculates all the internal position on the tile based on the nature density. Adds them to tilePositions.
    public void calculatePositions(int currentDensity)
    {
        tilePositions.Clear();
        //Vector3 pos;
        float stepSize = (10 / (currentDensity * 2));
        float x = tileGameObject.transform.position.x - stepSize * (currentDensity - 0.5f);
        float z = tileGameObject.transform.position.z - stepSize * (currentDensity - 0.5f);


        for (int i = 0; i < currentDensity; i++)
        {
            for (int j = 0; j < currentDensity; j++)
            {
                Vector3 pos = new Vector3(x, 0, z);
                Pair t = new Pair(pos, false);
                tilePositions.Add(t);
                x += stepSize * 3;

            }
            x = tileGameObject.transform.position.x - stepSize * (currentDensity - 0.5f);
            //x = x - stepSize * (natureDensity - 1);
            z += stepSize * 3;
        }

        //Debug.Log("density = " + currentDensity + " number of positions" + tilePositions.Count);
    }
    public void GrowObject(GameObject sampleObject)
    {
        if (sampleObject.name == "Spruce")
        {
            startGrowthPine();
        }
        if (sampleObject.name == "Birch")
        {
            startGrowthLeaf();
        }

    }
    public void startGrowthLeaf()
    {
        leafForest = true;
        startGrowth();
    }

    public void startGrowthPine()
    {
        pineForest = true;
        startGrowth();
    }


    public GameObject getTreeObject()
    {
        GameObject treeObject;

        if (pineForest)
            return GameObject.Find("SpawnMap").GetComponent<SpawnMap>().pineObject;

        else // leafForrest
            return GameObject.Find("SpawnMap").GetComponent<SpawnMap>().leafObject;
    }

    public void startGrowth()
    {

        // Calculates all the positions on the tile
        calculatePositions(3);

        if (forestID == -1)
            forestID = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().forestID++;
        //Debug.Log("Tree part of forrest " + forrestID);
        //GameObject.Find("SpawnMap").GetComponent<SpawnMap>().forrestID;

        GameObject treeObject = getTreeObject();

        // Grows a tree in the middle of the tile, starting the expansion process.
        float x = tileGameObject.transform.position.x;
        float z = tileGameObject.transform.position.z;
        //Debug.Log("tilePositions.Count at start: " + tilePositions.Count);
        Vector3 posVec = tilePositions[5].pos;
        tilePositions[5].filled = true;

        //treeObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        treeObject.transform.localScale = new Vector3(0, 0, 0);

        //treeObject.name = "Pine";

        treeObject = GameObject.Instantiate(treeObject, posVec, Quaternion.identity) as GameObject;
        treeObject.transform.parent = tileGameObject.transform;
        //Tree_Script
        if (pineForest)
        {
            treeObject.AddComponent<Birch>();
            treeObject.GetComponent<Birch>().SetForestID(forestID);
        }
        else
        {
            treeObject.AddComponent<Beech>();
            treeObject.GetComponent<Beech>().SetForestID(forestID);
        }

        //End Tree_Script

        tileTrees.Add(treeObject);
        grow = true;
    }

    public void destroyTrees()
    {
        foreach (var tree in tileTrees)
        {
            //Destroy(tree);
            //  Debug.Log("Destroying trees on tile.");
            UnityEngine.Object.Destroy(tree);
        }


        tileTrees.Clear();
        //if (tileTrees.Count == 0)
        //  Debug.Log("No trees left in array.");
    }


    public void placeTrees(Vector3 posVec)
    {
        // Places treeObjets on each available slot on the tile
        GameObject treeObject = getTreeObject();

        //foreach (var pos in tilePositions)
        //{
        //System.Random random = new System.Random();
        //float y = Random.Range(0.5f, 1.0f);
        //treeObject.transform.localScale = new Vector3(0.2f, y, 0.2f);
        treeObject.transform.localScale = new Vector3(0, 0, 0);

        treeObject = GameObject.Instantiate(treeObject, posVec, Quaternion.identity) as GameObject;
        treeObject.transform.parent = tileGameObject.transform;
        //Tree_script
        if (pineForest)
        {
            treeObject.AddComponent<Birch>();
            treeObject.GetComponent<Birch>().SetForestID(forestID);
        }
        else
        {
            treeObject.AddComponent<Beech>();
            treeObject.GetComponent<Beech>().SetForestID(forestID);
        }
        //End Tree_Script

        //treeObject.name = "pineTree";
        tileTrees.Add(treeObject);

        // Change the color of the tree to an RGB value. Can be randomized.
        /*Color treeColor = new Color(
 Random.Range(0f, 0f),
 Random.Range(0f, 1f),
 Random.Range(0f, 0f));
        pineGameObject.GetComponent<Renderer>().material.color = treeColor;*/

        //}

        //assest scale back to default
        //treeObject.transform.localScale = new Vector3(1, 1, 1);
    }


    public void calculateNeighbours()
    {
        // Add all surrounding tiles to neighbour list
        neighbours.Add((x - 1).ToString() + (y - 1).ToString());
        neighbours.Add((x - 1).ToString() + (y).ToString());
        neighbours.Add((x - 1).ToString() + (y + 1).ToString());

        neighbours.Add((x).ToString() + (y - 1).ToString());
        neighbours.Add((x).ToString() + (y + 1).ToString());

        neighbours.Add((x + 1).ToString() + (y - 1).ToString());
        neighbours.Add((x + 1).ToString() + (y).ToString());
        neighbours.Add((x + 1).ToString() + (y + 1).ToString());

        // Check that all the neighbours are valid tiles
        List<string> tmp = new List<string>();
        List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
        string s = "";
        foreach (var n in neighbours)
        {
            GameObject g = GameObject.Find(n);
            if (g != null)
            {
                tmp.Add(n);
                s += n + ", ";
            }
        }

        neighbours = tmp;


    }

    public void treeGrowth()
    {

        // If the current density is lower than cap, increase it each time function is called.
        Vector3 posVec = new Vector3();
        int index = 5;

        foreach (var tree in tileTrees)
        {
            expand = true;

            if (tree.transform.localScale.y < 0.5f)
            {
                expand = false;
            }

            if (tree.transform.localScale.y < 2f)
            {
                System.Random random = new System.Random();
                float var = (float)random.Next(0, 10);
                var = var / 10;
                tree.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            }




        }

        if (expand == true && tilePositions.Count != 1)
        {

            List<Pair> tmp = new List<Pair>();
            foreach (var t in tilePositions)
            {
                if (t.filled == false)
                    tmp.Add(t);
            }
            tilePositions = tmp;
            System.Random random = new System.Random();
            index = random.Next(0, tilePositions.Count);
            posVec = tilePositions[index].pos;
            placeTrees(posVec);
            tilePositions[index].filled = true;
            expand = false;
        }
        else if (tileTrees.Count == 9 && spread == true && neighbours.Count != 1)
        {
            //Debug.Log("Spreading...");
            spread = false;
            spreadTrees();
        }

        // Increase scale
        /*if (growthDone == false)
        foreach (var tree in tileTrees)
        {
          //Debug.Log("Increasing scale by 10%");
          if(tree.transform.localScale.y < 2f)
          Debug.Log("");
          //tree.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);

          else
            {
              growthDone = true;
            }
        }*/

    }

    private void spreadTrees()
    {
        // Randomize a neighbour and start growing there
        //Debug.Log("neighbours before:" + neighbours.Count);

        List<string> tmp = new List<string>();
        foreach (var n in neighbours)
        {
            if (n != "")
                tmp.Add(n);
        }
        neighbours = tmp;



        System.Random random = new System.Random();
        int index = random.Next(0, neighbours.Count);

        //Debug.Log("neighbours:" + neighbours.Count + " index: " + index);

        List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
        TileClass tile = tiles.Find(x => x.name == neighbours[index]);
        neighbours[index] = "";

        if (tile.grow == false)
        {
            tile.forestID = forestID;

            if (leafForest)
                tile.startGrowthLeaf();

            else
                tile.startGrowthPine();
        }




    }




}
