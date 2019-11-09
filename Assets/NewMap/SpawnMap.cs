using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileClass
{
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
    // Density
    public int natureDensity;
    public int currentDensity;
    // GameObject
    public GameObject tileGameObject;
    // Neighbours
    public List<string> neighbours;
    // Available positions
    private List<Vector3> tilePositions;
    // Trees on tile
    public List<GameObject> tileTrees;

    // Pine tree GameObject
    public GameObject pineGameObject;

    // Methods

    // Constructor
    public TileClass()
    {
        tilePositions = new List<Vector3>();
        neighbours = new List<string>();
        tileTrees = new List<GameObject>();
        grow = false;
        currentDensity = 2;
        natureDensity = 3;
        growthDone = false;
        spread = false;
        expand = false;
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
                tilePositions.Add(pos);
                x += stepSize * 2;

            }
            x = tileGameObject.transform.position.x - stepSize * (currentDensity - 1);
            //x = x - stepSize * (natureDensity - 1);
            z += stepSize * 2;
        }

        //Debug.Log("density = " + currentDensity + " number of positions" + tilePositions.Count);
      }

        public void startGrowthPine()
        {
          // Grows a pine tree in the middle of the tile, starting the expansion process.
          GameObject treeObject = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().treeObject;

          // Find middle of tile
          float x = tileGameObject.transform.position.x;
          float z = tileGameObject.transform.position.z;
          //Debug.Log("Tile starts at: " + (x-5f) + ", " + (z-5f) + "\n");
          //Debug.Log("Placing tree at: " + x + "," + z + "\n");



          treeObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.4f);
          pineGameObject = GameObject.Instantiate(treeObject, new Vector3(x, 0, z), Quaternion.identity) as GameObject;
          pineGameObject.transform.parent = tileGameObject.transform;
          tileTrees.Add(pineGameObject);
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


        public void placeTrees()
        {

          GameObject treeObject = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().treeObject;

          foreach (var pos in tilePositions)
          {
            System.Random random = new System.Random();
            float y = Random.Range(0.5f, 1.0f);
            treeObject.transform.localScale = new Vector3(0.3f, y, 0.4f);

            pineGameObject = GameObject.Instantiate(treeObject, pos, Quaternion.identity) as GameObject;
            pineGameObject.transform.parent = tileGameObject.transform;
            tileTrees.Add(pineGameObject);
            pineGameObject.name = "pineTreeObject " + (tileTrees.Count).ToString();
            /*Color treeColor = new Color(
     Random.Range(0f, 0f),
     Random.Range(0f, 1f),
     Random.Range(0f, 0f));
            pineGameObject.GetComponent<Renderer>().material.color = treeColor;*/
            //Debug.Log("Adding tree at " + pos.x + ", 0, " + pos.z);

          }
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

        // Check if all the neighbours are valid tiles
        List<string> tmp = new List<string>();
        List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
        string s = "";
        //Debug.Log("tiles.Count = " + tiles.Count);
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
        //Debug.Log("Tile " + name + " has neighbours: " + s);



    }

    public void treeGrowth()
    {
      grow = true;
      //Debug.Log("treeGrowth() called." + natureDensity);
      // If the current density is lower than cap, increase it each time function is called.
      if (currentDensity <= natureDensity && expand == true)
      {
        //Debug.Log("currentDensity = " + currentDensity);

          destroyTrees();
          calculatePositions(currentDensity);
          placeTrees();
          expand = false;
          //currentDensity++;
      }

      // When density cap is reached

        // Increase scale
        if (growthDone == false)
        foreach (var tree in tileTrees)
        {






          //Debug.Log("Increasing scale by 10%");
          if(tree.transform.localScale.y < 1.5f)
          tree.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);

          else
            {
              growthDone = true;
              spread = true;
            }
        }

        // when max scale is reached, spread


      if(spread == true)
        {
          spreadTrees();
          //spread = false;
        }
    }

    private void spreadTrees()
    {
      // Randomize a neighbour and start growing there
      System.Random random = new System.Random();
      int index = random.Next(0, neighbours.Count);
      //Debug.Log("neighbour chosen: " + neighbours[index]);
      List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
      TileClass tile = tiles.Find(x => x.name == neighbours[index]);
      //neighbours.Remove(neighbours[index]);
      tile.startGrowthPine();


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
    public GameObject treeObject;
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


    // Start is called before the first frame update
    void Start()
    {
        natureDensity = 5;
        drawMap();
        drawGraphic();
        //finished = true;

        // Test code for starting growth at tile 23
        TileClass tile = tiles.Find(x => x.name == "20");
        tile.startGrowthPine();
        InvokeRepeating("growth", 1.0f, 0.1f);
        InvokeRepeating("expand", 2.0f, 2.0f);

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
            tile.currentDensity++;
            tile.expand = true;
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
