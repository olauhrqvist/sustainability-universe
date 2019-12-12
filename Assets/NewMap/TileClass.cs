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

    public double staticVegetationOnTile; //do not change this value!


    //if we only implement the total amount of food on the tile without considiration of hierarchies.
    public double meatOnTile; // not used

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

        vegetationOnTile = 0;
        staticVegetationOnTile = vegetationOnTile;
}
    // Called on by SpawnMap. Sets all neighbours soil as the same type as original tile. Done this way
    // because we want larger chunks of the same soil type.
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
            z += stepSize * 3;
        }

    }

    // Called on from the UI scripts
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



    // Get for tree model
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
            staticVegetationOnTile = vegetationOnTile;
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
            staticVegetationOnTile = vegetationOnTile;
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
            staticVegetationOnTile = vegetationOnTile;

        }
    }

    // This function starts the growth of trees on a tile
    public void startGrowth()
    {
        // Calculates all the positions on the tile
        calculatePositions(3);

        if (forestID == -1)
            forestID = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().forestID++;
        if (grow == false)
        {
        GameObject treeObject = getTreeObject();

        // Grows a tree in the middle of the tile, starting the expansion process.
        float x = tileGameObject.transform.position.x;
        float z = tileGameObject.transform.position.z;
        Vector3 posVec = tilePositions[5].pos;
        tilePositions[5].filled = true;

        treeObject.transform.localScale = new Vector3(0, 0, 0);

        treeObject = GameObject.Instantiate(treeObject, posVec, Quaternion.identity) as GameObject;
        treeObject.transform.parent = tileGameObject.transform;
        treeObject.layer = 10;
        //Tree_Script
        addTreeData(treeObject);
        //End Tree_Script

        tileTrees.Add(treeObject);

        grow = true;
      }
    }



    // Places treeObjets on each available slot on the tile
    public void placeTrees(Vector3 posVec)
    {
        GameObject treeObject = getTreeObject();

        treeObject.transform.localScale = new Vector3(0, 0, 0);

        treeObject = GameObject.Instantiate(treeObject, posVec, Quaternion.identity) as GameObject;
        treeObject.transform.parent = tileGameObject.transform;
        treeObject.layer = 10;

        addTreeData(treeObject);
        tileTrees.Add(treeObject);

    }



    // Calculates all the possible neighbours and adds them to a list "neighbours".
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

    // Called repeatedly each year to grow the trees. If they are fully grown spreading will start.
    public void treeGrowth()
    {
        // If the current density is lower than cap, increase it each time function is called.
        Vector3 posVec = new Vector3();
        int index = 5;

        foreach (var tree in tileTrees)
        {
            //expand = true;


            if (tree.transform.localScale.y < 0.9f)
            {
                expand = false;
            }

            if (tree.transform.localScale.y < tree.GetComponent<Tree_Script>().GetScale())
            {

                float s = 0.01f;
                tree.transform.localScale += new Vector3(s, s, s);
            }

        }

        // When they are ready to expand...
        if (expand == true && tilePositions.Count != 1 && tileTrees.Count < 9)
        {

            List<Pair> tmp = new List<Pair>();
            foreach (var t in tilePositions)
            {
                if (t.filled == false)
                    tmp.Add(t);
            }
            tilePositions = tmp;
            index = random.Next(0, tilePositions.Count);
            posVec = tilePositions[index].pos;
            placeTrees(posVec);
            tilePositions[index].filled = true;
            expand = false;
        }

    }

    // Spread trees to a random neighbour that is not currently populated
    public void spreadTrees()
    {
        // Randomize a neighbour and start growing there
        if (tileTrees.Count < 9)
          return;

        List<string> tmp = new List<string>();
        foreach (var n in neighbours)
        {
            if (n != "")
                tmp.Add(n);
        }
        neighbours = tmp;



        //System.Random random = new System.Random();
        List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
        TileClass tile;
        int index = 0;
        if (neighbours.Count > 1)
          {
            index = random.Next(0, neighbours.Count);
            tile = tiles.Find(x => x.name == neighbours[index]);
            neighbours[index] = "";
          }
        else
          {
            tile = tiles.Find(x => x.name == neighbours[0]);
            //neighbours[0] = "";
          }


        if (tile.grow == false)
        {
            //tile.forestID = forestID;

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

        }





    }




}
