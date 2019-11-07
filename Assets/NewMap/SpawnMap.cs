﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileClass
{
    // Variables

    // Tile ID

    // Coordinate

    // Density
    public int natureDensity;
    // GameObject
    public GameObject tileGameObject;
    // Neighbours
    private List<string> neighbours;
    // Available positions
    private List<Vector3> tilePositions;




    // Methods

    // Constructor
    public TileClass()
    {

        tilePositions = new List<Vector3>();

    }

// Calculates all the internal position on the tile based on the nature density. Adds them to tilePositions.
    public void calculatePositions()
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
    }

    public void calculateNeighbours()
    {

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

        /*if (N > 50)
        {
            N = 50;
        }
            
        x = (-(tileSize/2) * ((float)N-1));
        z = (-(tileSize/2) * ((float)N-1));
        char[] alpha = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        for (int i = 0; i < N; i++) // x
        {
            for (int j = 0; j < N; j++) //y 
            {
                tile = Instantiate(planeTile, new Vector3(x, 0, z), transform.rotation);
                //planeColor = new Color(107f, 141f, 75f);
                tile.GetComponent<Renderer> ().material.color = planeColor;
                float stepSize = (tileSize/(natureDensity * 2));
                float xTree = x - stepSize * (natureDensity - 1);
                float zTree = z - stepSize * (natureDensity - 1);
                //Debug.Log("Spawned tile at: " + "0 > " + x + ", 0 > " + z);
                //Debug.Log("Stepsize: " + stepSize);

                //small location with density 5 , 1 for each step
                float stepS = (tileSize / (5 * 2));
                float xSmall = x - stepS * (5 - 1);
                float zSmall = z - stepS * (5 - 1);
                findSmallLocations(xSmall, zSmall, stepS);

                //add trees
                //if (i < N / 2 && j < N/2)
                //{
                //    addTrees(xTree, zTree, stepSize);
                //}

                tile.name = alpha[i] + j.ToString();
                tile.tag = "tile";
                tileMap.Add(tile);    
                z += tileSize;
            }
            x += tileSize;
            z = (-(tileSize/2) * ((float)N-1));  
    }
        finished = true;*/
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
                tile.tileGameObject.tag = "tile";
                tile.tileGameObject.GetComponent<Renderer>().material.color = planeColor;
                tile.natureDensity = natureDensity;

                tile.calculatePositions();
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
        spwanMountain();
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
        int cloudNum = N / 3;
        for (int i = 0; i < cloudNum; i++)
        {
            Vector3 location = smallLocation[Random.Range(0, (smallLocation.Count) - 1)];
            location.y = Random.Range(30, 50);
            cloud1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Instantiate(cloud1, location, transform.rotation);
        }

    }

    public void spwanMountain()
    {
        if (N < 4)
            return;

        x = (-(tileSize / 2) * ((float)N - 1));
        z = (-(tileSize / 2) * ((float)N - 1));

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (i == N / 2 && j == 0)
                {
                    mountain1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    Instantiate(mountain1, new Vector3(x, 0, z - (tileSize * 3)), transform.rotation);
                }

                if (i == 0 && j == N / 2)
                {
                    mountain2.transform.localScale = new Vector3(0.4f, 0.45f, 0.4f);
                    Instantiate(mountain2, new Vector3(x - (tileSize * 4), 0, z), transform.rotation);
                }
                if (N > 9)
                {
                    if (i == N - 1 && j == 0)
                    {
                        mountain1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Instantiate(mountain1, new Vector3(x, 0, z - (tileSize * 3)), transform.rotation);
                    }
                    if (i == 0 && j == 0)
                    {
                        mountain1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Instantiate(mountain1, new Vector3(x + (tileSize * 2), 0, z - (tileSize * 3)), transform.rotation);

                        mountain2.transform.localScale = new Vector3(0.45f, 0.45f, 0.45f);
                        Instantiate(mountain2, new Vector3(x - (tileSize * 4), 0, z - tileSize), transform.rotation);
                    }
                    if (i == 0 && j == N - 1)
                    {
                        mountain2.transform.localScale = new Vector3(0.45f, 0.5f, 0.45f);
                        Instantiate(mountain2, new Vector3(x - (tileSize * 4), 0, z), transform.rotation);
                    }
                }

                z += tileSize;
            }
            x += tileSize;
            z = (-(tileSize / 2) * ((float)N - 1));
        }

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
