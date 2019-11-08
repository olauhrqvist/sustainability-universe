using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileClass
{
    // Variables

    // Tile ID

    // Coordinate
    public int x;
    public int y;

    // Density
    public int natureDensity;
    // GameObject
    public GameObject tileGameObject;
    // Neighbours
    public List<string> neighbours;
    // Available positions
    private List<Vector3> tilePositions;
    // Trees on tile
    public GameObject[] tileTrees;



    // Methods

    // Constructor
    public TileClass()
    {
        tilePositions = new List<Vector3>();
        neighbours = new List<string>();


    }

    // Calculates all the internal position on the tile based on the nature density. Adds them to tilePositions.
    public void calculatePositions(int natureDensity)
    {
        //Vector3 pos;
        float stepSize = (10 / (natureDensity * 2));
        float x = tileGameObject.transform.position.x - stepSize * (natureDensity - 1);
        float z = tileGameObject.transform.position.z - stepSize * (natureDensity - 1);


        for (int i = 0; i < natureDensity; i++)
        {
            for (int j = 0; j < natureDensity; j++)
            {
                Vector3 pos = new Vector3((int)x, 0, (int)z);
                tilePositions.Add(pos);
                x += stepSize * 2;

            }

            x = x - stepSize * (natureDensity - 1);
            z += stepSize * 2;
        }

        void placeTrees(List<Vector3> tilePositions)
        {
            foreach (var position in tilePositions)
            {
                //GameObject tree = Instantiate(treeObject, position, transform.rotation);
                //tileTrees.add(tree);
            }

        }

        void destroyTrees()
        {
            foreach (var tree in tileTrees)
            {
                //Destroy(tree);
            }
        }

        void increaseScale()
        {
            foreach (var tree in tileTrees)
            {
                
            }
        }
    }

    public void calculateNeighbours()
    {
        neighbours.Add((x - 1).ToString() + (y - 1).ToString());
        neighbours.Add((x - 1).ToString() + (y).ToString());
        neighbours.Add((x - 1).ToString() + (y + 1).ToString());

        neighbours.Add((x).ToString() + (y - 1).ToString());
        neighbours.Add((x).ToString() + (y + 1).ToString());

        neighbours.Add((x + 1).ToString() + (y - 1).ToString());
        neighbours.Add((x + 1).ToString() + (y).ToString());
        neighbours.Add((x + 1).ToString() + (y + 1).ToString());

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


    // Start is called before the first frame update
    void Start()
    {
        drawMap();
        drawGraphic();
        finished = true;
        GameObject tile = GameObject.Find("23");
        Instantiate(treeObject, tile.transform.position, transform.rotation);

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
                tile.x = i;
                tile.y = j;

                tile.tileGameObject.tag = "tile";
                tile.tileGameObject.GetComponent<Renderer>().material.color = planeColor;
                tile.natureDensity = natureDensity;

                tile.calculatePositions(natureDensity);
                tile.calculateNeighbours();

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

    // Update is called once per frame
    void Update()
    {
        
    }


}
