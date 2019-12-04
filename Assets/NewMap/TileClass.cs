using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClass : MonoBehaviour
{
    //Main Database



    // public Global_Database Database;
    public Global_Database globalDatabase;
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

    bool spruceForest;
    bool birchForest;
    bool beechForest;


    public int forestID;
    public int Nutrition;

    public string Groundtype;
    private System.Random random = new System.Random();


    //OnTileData variables
    public List<double> foodHierarchy;
    public double vegetationOnTile;

    //if we only implement the total amount of food on the tile without considiration of hierarchies.
    public double meatOnTile;





    // Constructor
    public TileClass()
    {
        int id = 0;
        int pH = 0;
        int Moisture = 100;
        //int Nutrition;
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

        spruceForest = false;
        birchForest = false;
        beechForest = false;

        //OnTileData
        foodHierarchy = new List<double>();
        foodHierarchy.Add(0);
        foodHierarchy.Add(0);
        foodHierarchy.Add(0);
        foodHierarchy.Add(0);
        foodHierarchy.Add(0);

        //if we only implement the total amount of food on the tile without considiration of hierarchies.
        meatOnTile = 0;

        //print("size: " + foodHierarchy.Count);

        vegetationOnTile = 0;

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
    public void GrowObject(string SpawnType, string type)
    {
        switch (type)
        {
            case "Tree":
                switch (SpawnType)
                {
                    case "Spruce":
                        spruceForest = true;
                        startGrowth();
                        // database.AddToDataBase(database.SpruceList, sampleObject, name);
                       //Debug.Log("Should grow neighbour");
                        break;

                    case "Birch":
                        birchForest = true;
                        startGrowth();
                        break;

                    case "Beech":
                        beechForest = true;
                        startGrowth();
                        break;

                    default:
                       //Debug.Log("Tree not found : " + SpawnType);
                        break;
                }
                break;

            case "Carnivore":
                switch (SpawnType)
                {
                    case "Shrew":
                        break;

                    case "Weasel":
                        break;

                    case "Fox":
                        break;

                    case "Wolf":
                        break;

                    default:
                       //Debug.Log("Carnivore not found : " + SpawnType);
                        break;
                }
                break;

            case "Herbivore":
                switch (SpawnType)
                {
                    case "Mouse":
                        break;

                    case "Hare":
                        break;

                    case "RoeDeer":
                        break;

                    case "Moose":
                        break;

                    default:
                       //Debug.Log("Herbivore not found : " + SpawnType);
                        break;
                }
                break;

            case "Omnivore":
                switch (SpawnType)
                {
                    case "Squirrel":
                        break;

                    case "Rat":
                        break;

                    case "Boar":
                        break;

                    case "BrownBear":
                        break;

                    default:
                       //Debug.Log("Omnivore not found : " + SpawnType);
                        break;
                }
                break;

            default:
               //Debug.Log("Type not found : " + type);
                break;

        }
    }
    /*public void startGrowthLeaf()
    {
        leafForest = true;
        startGrowth();
    }

    public void startGrowthPine()
    {
        pineForest = true;
        startGrowth();
    }*/


    public GameObject getTreeObject()
    {

      if (spruceForest)
        return GameObject.Find("SpawnMap").GetComponent<SpawnMap>().spruceObject;

      else if (birchForest)
        return GameObject.Find("SpawnMap").GetComponent<SpawnMap>().birchObject;

      else if (beechForest)
        return GameObject.Find("SpawnMap").GetComponent<SpawnMap>().beechObject;

      else
        return null;
        /*
        if (pineForest)
            return GameObject.Find("SpawnMap").GetComponent<SpawnMap>().pineObject;

        else // leafForrest
            return GameObject.Find("SpawnMap").GetComponent<SpawnMap>().leafObject;*/
    }

    //addTreeData() : add scripts to each tree and add each tree to the global database
    private void addTreeData(GameObject treeObject)
    {
        float n = Random.Range(10, 20);
        float s = n / 10f;
        globalDatabase = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().globalDatabase;
        if (spruceForest)
        {
            treeObject.AddComponent<Tree_Script>();
            treeObject.GetComponent<Tree_Script>().SetForestID(forestID);
            treeObject.GetComponent<Tree_Script>().SetScale(s);
            globalDatabase.AddTreetype(tileGameObject.name, "Spruce", treeObject);
            globalDatabase.AddSpruce(tileGameObject.name, treeObject);

            vegetationOnTile += 150;
        }
        else if (birchForest)
        {
            BirchInfo tmp = new BirchInfo();
            vegetationOnTile += tmp.vegetationValue;
            treeObject.AddComponent<Tree_Script>();
            treeObject.GetComponent<Tree_Script>().SetForestID(forestID);
            treeObject.GetComponent<Tree_Script>().SetScale(s);
            globalDatabase.AddTreetype(tileGameObject.name, "Birch", treeObject);
            globalDatabase.AddBirch(tileGameObject.name, treeObject);

            vegetationOnTile += 100;
        }
        else
        {
            BeechInfo tmp = new BeechInfo();
            vegetationOnTile += tmp.vegetationValue;
           //Debug.Log("vegetationOnTile: " + vegetationOnTile);
            treeObject.AddComponent<Tree_Script>();
            treeObject.GetComponent<Tree_Script>().SetForestID(forestID);
            treeObject.GetComponent<Tree_Script>().SetScale(s);
            globalDatabase.AddTreetype(tileGameObject.name, "Beech", treeObject);
            globalDatabase.AddBeech(tileGameObject.name, treeObject);

            vegetationOnTile += 200;

        }
    }

    public void startGrowth()
    {
        // Calculates all the positions on the tile
        calculatePositions(3);

        if (forestID == -1)
            forestID = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().forestID++;
        //Debug.Log("Tree part of forrest " + forrestID);
        //GameObject.Find("SpawnMap").GetComponent<SpawnMap>().forrestID;
        if (grow == false)
        {
        GameObject treeObject = getTreeObject();

        // Grows a tree in the middle of the tile, starting the expansion process.
        float x = tileGameObject.transform.position.x;
        float z = tileGameObject.transform.position.z;
        //Debug.Log("tilePositions.Count at start: " + tilePositions.Count);
        Vector3 posVec = tilePositions[5].pos;
        tilePositions[5].filled = true;

       //Debug.Log("Starting growth on tile " + treeObject.transform.position);
        //treeObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        treeObject.transform.localScale = new Vector3(0, 0, 0);

        //treeObject.name = "Pine";

        treeObject = GameObject.Instantiate(treeObject, posVec, Quaternion.identity) as GameObject;
        treeObject.transform.parent = tileGameObject.transform;
        //Tree_Script
        addTreeData(treeObject);
        //End Tree_Script

        tileTrees.Add(treeObject);

        grow = true;
      }
    }

    public void destroyTrees()
    {
        foreach (var tree in tileTrees)
        {
            //Destroy(tree);
            // //Debug.Log("Destroying trees on tile.");
            UnityEngine.Object.Destroy(tree);
        }


        tileTrees.Clear();
        //if (tileTrees.Count == 0)
        // //Debug.Log("No trees left in array.");
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
        //Debug.Log("Keep growing on tile " + treeObject.transform.position);


        // Change the color of the tree to an RGB value. Can be randomized.
        //Color treeColor = new Color(Random.Range(50, 100), Random.Range(150, 255), 0, 0.5f);
        //Debug.Log("color: " + treeColor);
        //treeObject.GetComponent<Renderer>().material.color = treeColor;

        //}
        //Tree_script
        addTreeData(treeObject);
        //End Tree_Script

        //treeObject.name = "pineTree";
        tileTrees.Add(treeObject);

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

            if (tree.transform.localScale.y < tree.GetComponent<Tree_Script>().GetScale())
            {

                float s = 0.01f;
                tree.transform.localScale += new Vector3(s, s, s);
            }




        }

        if (expand == true && tilePositions.Count != 1 && tileTrees.Count < 9)
        {

            List<Pair> tmp = new List<Pair>();
            foreach (var t in tilePositions)
            {
                if (t.filled == false)
                    tmp.Add(t);
            }
            tilePositions = tmp;
            //System.Random random = new System.Random();
            index = random.Next(0, tilePositions.Count);
            posVec = tilePositions[index].pos;
            placeTrees(posVec);
            tilePositions[index].filled = true;
            expand = false;
        }
        else if (tileTrees.Count == 9 && spread == true && neighbours.Count != 1)
        {
            //Debug.Log("Spreading. tileTrees:Count:" + tileTrees.Count);
            spread = false;
            spreadTrees();
        }

        // Increase scale
        /*if (growthDone == false)
        foreach (var tree in tileTrees)
        {
          //Debug.Log("Increasing scale by 10%");
          if(tree.transform.localScale.y < 2f)
         //Debug.Log("");
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



        //System.Random random = new System.Random();
        int index = random.Next(0, neighbours.Count);

        //Debug.Log("neighbours:" + neighbours.Count + " index: " + index);

        List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
        TileClass tile = tiles.Find(x => x.name == neighbours[index]);
        neighbours[index] = "";

        if (tile.grow == false)
        {
            tile.forestID = forestID;

            if (spruceForest)
            {
              //Debug.Log("Grow neighbour spruce.");
              tile.GrowObject("Spruce", "Tree");
            }

            else if (birchForest)
            {
              //Debug.Log("Grow neighbour birch.");
              tile.GrowObject("Birch", "Tree");
            }

            else if (beechForest)
            {
              //Debug.Log("Grow neighbour beech.");
              tile.GrowObject("Beech", "Tree");
            }

            /*
            if (leafForest)
                tile.startGrowthLeaf();

            else
                tile.startGrowthPine();*/
        }





    }




}
