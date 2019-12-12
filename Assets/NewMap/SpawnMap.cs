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

public class SpawnMap : MonoBehaviour
{
    private float x; //tile position x
    private float z;//tile position y
    private GameObject tile;
    private GameObject tree;

    public float tileSize = 10; // size of each tile
    public int N = 8; // default size of the map is 8*8, but this value can be set in the inspector of unity.
    public Color planeColor; // color of the tile

    //Public game object list, which you need to drag the prefab or object to the relavant place in inspector.
    public GameObject planeTile;
    public GameObject pineObject;
    public GameObject leafObject;
    public GameObject spruceObject;
    public GameObject birchObject;
    public GameObject beechObject;
    public GameObject mountain1;
    public GameObject mountain2;
    public GameObject mountain3;
    public GameObject cloud1;
    public GameObject grass1;
    public GameObject grass2;
    public GameObject rock;
    public GameObject flower;
    // End of the public game object list.

    public int natureDensity; // density of trees, plants, ect.
    public List<GameObject> tileMap; // list of tiles
    public List<Vector3> smallLocation; //available locations for small things such as rock, grass,flower.

    public bool finished = false;
    public List<TileClass> tiles = new List<TileClass>();
    public int forestID = 0;
    private System.Random random = new System.Random();

    public Global_Database globalDatabase;//= new Global_Database();

    // Tile Dictionary key="x"+"y"
    public Dictionary<string, TileClass> TileDict = new Dictionary<string, TileClass>();


    // Start is called before the first frame update
    void Start()
    {
        globalDatabase = new Global_Database();
        natureDensity = 5;
        drawMap(); // spawn map
        drawGraphic(); // create nature around the map, mountains, clouds, flowers,ect.
        markGroundtype();
        InvokeRepeating("growth", 1.0f, 0.1f);

        // Building a dictionary for all tiles for fast access
        BuildDictionary();

    }
    public void BuildDictionary()
    {
        string temp = "";
        foreach (var T in tiles)
        {
            temp += T.x;
            temp += T.y;
            TileDict[temp] = T;
            temp = "";
        }
    }

    // Marks every tile as either brownearth or podzol.
    void markGroundtype()
    {
      // Place two kinds of types on the map and have them spread
      System.Random random = new System.Random();

      for (int i  = 0; i < 10; i++)
      {
        int index = random.Next(0, tiles.Count);
        tiles[index].Groundtype = "podzol";
      }
      for (int i  = 0; i < 10; i++)
      {
        int index = random.Next(0, tiles.Count);
        tiles[index].Groundtype = "brownearth";

      }


      // spread the soil over the map
      spread:
      foreach (var t in tiles)
        if (t.Groundtype != "")
          t.markGroundtype();

      foreach (var t in tiles)
          if (t.Groundtype == "")
            goto spread;





      foreach (var tile in tiles)
      {

        tile.calculateNeighbours();

      }

    }

    void spread()
    {
        foreach (var tile in tiles)
        {
            if (tile.grow)
            {
                tile.spread = true;
            }
        }
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
                //tile.spread = true;
            }
        }
    }

    void drawMap()  // create the map which consists of planes.
    {
        x = (-(tileSize / 2) * ((float)N - 1));
        z = (-(tileSize / 2) * ((float)N - 1));


        // Draws a two-dimensional field with planes.
        for (int i = 0; i < N; i++) // x
        {
            for (int j = 0; j < N; j++) //y
            {
                TileClass tile = gameObject.AddComponent<TileClass>();
                tile.tileGameObject = Instantiate(planeTile, new Vector3(x, 0, z), transform.rotation);
                tile.tileGameObject.name = i.ToString() + j.ToString();
                tile.name = i.ToString() + j.ToString();

                tile.Nutrition = random.Next(75, 125);
                tile.x = i;
                tile.y = j;

                tile.tileGameObject.tag = "tile";
                tile.tileGameObject.GetComponent<Renderer>().material.color = planeColor;
                tile.natureDensity = natureDensity;

                tile.calculatePositions(natureDensity);
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

    public void spwanBorder() // mountains around
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


    void findSmallLocations(float xSmall, float zSmall, float stepS) // find locations for small nature objects: flowers, rocks, ect.
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
