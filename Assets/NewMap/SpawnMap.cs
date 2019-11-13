using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pair
{
    public Vector3 pos;
    public bool filled;

    public Pair(Vector3 v, bool b)
    {
        pos = v;
        filled = b;
    }
}

public class TileClass
{

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
    bool pineForrest;
    bool leafForrest;
    public int forrestID;

    // Constructor
    public TileClass()
    {
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


        pineForrest = false;
        leafForrest = false;

        forrestID = -1;

    }

    // Calculates all the internal position on the tile based on the nature density. Adds them to tilePositions.
    public void calculatePositions(int currentDensity)
    {
        tilePositions.Clear();
        //Vector3 pos;
        float stepSize = (10 / (currentDensity * 2));
        float x = tileGameObject.transform.position.x - stepSize * (currentDensity - 1);
        float z = tileGameObject.transform.position.z - stepSize * (currentDensity - 1);


        for (int i = 0; i < currentDensity; i++)
        {
            for (int j = 0; j < currentDensity; j++)
            {
                Vector3 pos = new Vector3(x, 0, z);
                Pair t = new Pair(pos, false);
                tilePositions.Add(t);
                x += stepSize * 2;

            }
            x = tileGameObject.transform.position.x - stepSize * (currentDensity - 1);
            //x = x - stepSize * (natureDensity - 1);
            z += stepSize * 2;
        }

        //Debug.Log("density = " + currentDensity + " number of positions" + tilePositions.Count);
      }

        public void startGrowthLeaf()
        {
          leafForrest = true;
          startGrowth();
        }

        public void startGrowthPine()
        {
          pineForrest = true;
          startGrowth();
        }


        public GameObject getTreeObject()
        {
          GameObject treeObject;

          if (pineForrest)
            return GameObject.Find("SpawnMap").GetComponent<SpawnMap>().pineObject;

          else // leafForrest
              return GameObject.Find("SpawnMap").GetComponent<SpawnMap>().leafObject;
        }

        public void startGrowth()
        {

          // Calculates all the positions on the tile
          calculatePositions(5);

          if (forrestID == -1)
            forrestID = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().forrestID++;
          //Debug.Log("Tree part of forrest " + forrestID);
          //GameObject.Find("SpawnMap").GetComponent<SpawnMap>().forrestID;

          GameObject treeObject = getTreeObject();

          // Grows a tree in the middle of the tile, starting the expansion process.
          float x = tileGameObject.transform.position.x;
          float z = tileGameObject.transform.position.z;
          //Debug.Log("tilePositions.Count at start: " + tilePositions.Count);
          Vector3 posVec = tilePositions[13].pos;
          tilePositions[13].filled = true;

          treeObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
          //treeObject.name = "Pine";
          treeObject = GameObject.Instantiate(treeObject, posVec, Quaternion.identity) as GameObject;
          treeObject.transform.parent = tileGameObject.transform;
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
            System.Random random = new System.Random();
            float y = Random.Range(0.5f, 1.0f);
            treeObject.transform.localScale = new Vector3(0.2f, y, 0.2f);

            treeObject = GameObject.Instantiate(treeObject, posVec, Quaternion.identity) as GameObject;
            treeObject.transform.parent = tileGameObject.transform;
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
      //  treeObject.transform.localScale = new Vector3(1, 1, 1);
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
      int index = 13;

      if (expand == true && tilePositions.Count != 1)
      {

        List<Pair> tmp = new List<Pair>();
        foreach (var t in tilePositions)
        {
          if(t.filled == false)
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
      else if (tileTrees.Count == 25 && spread == true && neighbours.Count != 1)
      {
        //Debug.Log("Spreading...");
        spread = false;
        spreadTrees();
      }

        // Increase scale
        if (growthDone == false)
        foreach (var tree in tileTrees)
        {
          //Debug.Log("Increasing scale by 10%");
          if(tree.transform.localScale.y < 2f)
          tree.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);

          else
            {
              growthDone = true;
            }
        }

    }

    private void spreadTrees()
    {
      // Randomize a neighbour and start growing there
      Debug.Log("neighbours before:" + neighbours.Count);

      List<string> tmp = new List<string>();
      foreach (var n in neighbours)
      {
        if(n != "")
          tmp.Add(n);
      }
      neighbours = tmp;



      System.Random random = new System.Random();
      int index = random.Next(0, neighbours.Count);

      Debug.Log("neighbours:" + neighbours.Count + " index: " + index);

      List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
      TileClass tile = tiles.Find(x => x.name == neighbours[index]);
      neighbours[index] = "";

      if (tile.grow == false)
        {
          tile.forrestID = forrestID;

          if(leafForrest)
              tile.startGrowthLeaf();

          else
            tile.startGrowthPine();
        }




    }



}



public class SpawnMap : MonoBehaviour
{
    private float x;
    private float z;
    private GameObject tile;
    private GameObject tree;

    private float tileSize = 10;
    public int N = 8;
    public Color planeColor;

    public GameObject planeTile;
    public GameObject pineObject;
    public GameObject leafObject;

    public GameObject mountain1;
    public GameObject mountain2;
    public GameObject mountain3;
    public GameObject cloud1;
    public GameObject grass1;
    public GameObject grass2;
    public GameObject rock;
    public GameObject flower;
    public int natureDensity;
    public List<GameObject> tileMap;
    public List<Vector3> smallLocation;
    //public List<GameObject> tileMap;

    public bool finished = false;
    public List<TileClass> tiles = new List<TileClass>();
    public int forrestID = 0;




    // Start is called before the first frame update
    void Start()
    {
        natureDensity = 5;
        drawMap();
        drawGraphic();
        //finished = true;

        // Test code for starting growth at tile 23
        TileClass tile = tiles.Find(x => x.name == "14");
        tile.startGrowthPine();


        tile = tiles.Find(x => x.name == "28");
        tile.startGrowthLeaf();

        tile = tiles.Find(x => x.name == "41");
        tile.startGrowthLeaf();

        tile = tiles.Find(x => x.name == "79");
        tile.startGrowthPine();

        InvokeRepeating("growth", 1.0f, 0.1f);
        InvokeRepeating("expand", 0.1f, 0.1f);
        //InvokeRepeating("spread", 2.0f, 2.0f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void growth()
    {
      foreach (var tile in tiles)
      {
        if (tile.grow)
          tile.treeGrowth();
      }
    }

    void expand()
    {
      foreach (var tile in tiles)
      {
        if (tile.grow)
        {
            tile.expand = true;
            tile.spread = true;
        }
      }
    }

    void drawMap()
    {
        x = (-(tileSize / 2) * ((float)N - 1));
        z = (-(tileSize / 2) * ((float)N - 1));

        for (int i = 0; i < N; i++) // x
        {
            for (int j = 0; j < N; j++) //y
            {
                TileClass tile = new TileClass();
                tile.tileGameObject = Instantiate(planeTile, new Vector3(x, 0, z), transform.rotation);
                tile.tileGameObject.name = i.ToString() + j.ToString();
                tile.name = i.ToString() + j.ToString();
                tile.x = i;
                tile.y = j;

                tile.tileGameObject.tag = "tile";
                tile.tileGameObject.GetComponent<Renderer>().material.color = planeColor;
                tile.natureDensity = natureDensity;

                tile.calculatePositions(natureDensity);
                //tile.calculateNeighbours();
                tiles.Add(tile);

                // Added find small location functions, so the smallLocation vector has data inside
                float stepS = (tileSize / (5 * 2));
                float xSmall = x - stepS * (5 - 1);
                float zSmall = z - stepS * (5 - 1);
                findSmallLocations(xSmall, zSmall, stepS);

                z += tileSize;
            }

            x += tileSize;
            z = (-(tileSize / 2) * ((float)N - 1));
        }

        foreach (var tile in tiles)
          tile.calculateNeighbours();
    }

    void drawGraphic()
    {
        //all the postions of graphic model below are random position in smallLocation vector
        //Vector3 location = smallLocation[Random.Range(0, (smallLocation.Count) - 1)];
        spawnRocks();
        spawnGrass();
        spawnFlower();
        spawnCloud();
        spawnCloud();
        spwanBorder();
    }


    public void spawnRocks()
    {
        int Num = (N / 10) * 10;
        for (int i = 0; i < Num; i++)
        {
            Vector3 location = smallLocation[Random.Range(0, (smallLocation.Count) - 1)];
            Instantiate(rock, location, transform.rotation);
        }

    }

    public void spawnGrass()
    {
        int Num = (N / 10) * 10;
        for (int i = 0; i < Num; i++)
        {
            Vector3 location = smallLocation[Random.Range(0, (smallLocation.Count) - 1)];
            Instantiate(grass1, location, transform.rotation);
        }
        for (int i = 0; i < Num; i++)
        {
            Vector3 location = smallLocation[Random.Range(0, (smallLocation.Count) - 1)];
            Instantiate(grass2, location, transform.rotation);
        }
    }

    public void spawnFlower()
    {
        int Num = (N / 10) * 10;
        for (int i = 0; i < Num; i++)
        {
            Vector3 location = smallLocation[Random.Range(0, (smallLocation.Count) - 1)];
            Instantiate(flower, location, transform.rotation);
        }

    }

    public void spawnCloud()
    {
        int cloudNum = N / 5;
        for (int i = 0; i < cloudNum; i++)
        {
            Vector3 location = smallLocation[Random.Range(0, (smallLocation.Count) - 1)];
            location.y = Random.Range(30, 50);
            cloud1.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            Instantiate(cloud1, location, transform.rotation);
        }

    }

    public void spwanBorder()
    {
        if (N < 4)
            return;

        x = (-(tileSize / 2) * ((float)N - 1));
        z = (-(tileSize / 2) * ((float)N - 1));

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {


                if (i%5==0 && j == 0)
                {
                    float n = Random.Range(50,80);
                    float s = n / 100f;
                    mountain1.transform.localScale = new Vector3(s, s, s);
                    Instantiate(mountain1, new Vector3(x, 0, z - (tileSize * 4)), transform.rotation);
                }

                if (i == 0 && j%4==0)
                {
                    float n = Random.Range(30, 60);
                    float s = n / 100f;
                    mountain2.transform.localScale = new Vector3(s, s, s);
                    Instantiate(mountain2, new Vector3(x - (tileSize * 4), 0, z), transform.rotation);
                }
                if (i % 5 == 0 && j == N-1)
                {
                    float n = Random.Range(70, 100);
                    float s = n / 100f;
                    mountain3.transform.localScale = new Vector3(s, s, s);
                    Instantiate(mountain3, new Vector3(x, 0, z + (tileSize * 4)), transform.rotation);
                }
                z += tileSize;
            }
            x += tileSize;
            z = (-(tileSize / 2) * ((float)N - 1));
        }
        mountain1.transform.localScale = new Vector3(1, 1, 1);
        mountain2.transform.localScale = new Vector3(1, 1, 1);
        mountain3.transform.localScale = new Vector3(1, 1, 1);
    }


    void findSmallLocations(float xSmall, float zSmall, float stepS)
    {
        for (int k = 0; k < 5; k++)
        {
            for (int l = 0; l < 5; l++)
            {
                smallLocation.Add(new Vector3(xSmall, 0, zSmall));
                xSmall += stepS * 2;
            }
            xSmall = x - stepS * (5 - 1);
            zSmall += stepS * 2;
        }
    }

    public List<TileClass> Getlist()
    {
        return tiles;
    }

    /*void addTrees(float xTree, float zTree, float stepSize)
    {
        int u = 0;
        for (int k = 0; k < natureDensity; k++)
        {

            for (int l = 0; l < natureDensity; l++)
            {

                tree = Instantiate(treeObject, new Vector3(xTree, 0, zTree), transform.rotation);
                tree.transform.parent = tile.transform;
                tree.name = "Bush " + u;
                tree.tag = "Plant";
                u++;

                xTree += stepSize * 2;
            }

            xTree = x - stepSize * (natureDensity - 1);
            zTree += stepSize * 2;
        }
    }*/




}
