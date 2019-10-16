using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{


    private float x;
    private float z;
    private GameObject tile;
    private GameObject tree;
    public GameObject mountain1;
    public GameObject mountain2;

    private float tileSize = 10;
    public int N = 8;
    public Color planeColor;


    public GameObject planeTile;
    public GameObject treeObject;
    public int natureDensity;
    public List<GameObject> tileMap;
    public List<Vector3> smallLocation;


    // Start is called before the first frame update
    void Start()
    {
        x = (-(tileSize/2) * ((float)N-1));
        z = (-(tileSize/2) * ((float)N-1));
        int u = 0;

        for (int i = 0; i < N; i++) // x
        {
            for (int j = 0; j < N; j++) //y 
            {
                if (i == N / 2 && j == 0)
                {
                    mountain1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    Instantiate(mountain1, new Vector3(x, 0, z-(tileSize*2)), transform.rotation);
                }
                if (i == 0 && j == N /2)
                {
                    mountain2.transform.localScale = new Vector3(0.4f, 0.45f, 0.4f);
                    Instantiate(mountain2, new Vector3(x - (tileSize * 4), 0, z), transform.rotation);
                }
                if (i == 0 && j == 0)
                {
                    mountain2.transform.localScale = new Vector3(0.45f, 0.45f, 0.45f);
                    Instantiate(mountain2, new Vector3(x - (tileSize * 4), 0, z-tileSize), transform.rotation);
                }
                if (i == 0 && j == N-1)
                {
                    mountain2.transform.localScale = new Vector3(0.45f, 0.5f, 0.45f);
                    Instantiate(mountain2, new Vector3(x - (tileSize * 4), 0, z), transform.rotation);
                }

                tile = Instantiate(planeTile, new Vector3(x, 0, z), transform.rotation);
                //planeColor = new Color(107f, 141f, 75f);
                tile.GetComponent<Renderer> ().material.color = planeColor;


                float stepSize = (tileSize/(natureDensity * 2));
                float xTree = x - stepSize * (natureDensity - 1);
                float zTree = z - stepSize * (natureDensity - 1);
                //Debug.Log("Spawned tile at: " + "0 > " + x + ", 0 > " + z);
                //Debug.Log("Stepsize: " + stepSize);
                // small Location with fixed density, should have enough positions 
                float stepS = (tileSize / (4 * 2));
                float xSmall = x - stepSize * (4 - 1);
                float zSmall = z - stepSize * (4 - 1);
                findSmallLocations(xSmall, zSmall, stepS, u);

                if (i < N / 2 && j < N/2)
                {
                    addTrees(xTree, zTree, stepSize,u);
                }

                tile.name = "Tile" + tile.transform.position;
                tile.tag = "tile";
                tileMap.Add(tile);
                
                z += tileSize;
            }

            x += tileSize;
            z = (-(tileSize/2) * ((float)N-1));  

    }
    
            
        
}

    void findSmallLocations(float xSmall, float zSmall, float stepS, int u)
    {
        for (int k = 0; k < 4; k++)
        {

            for (int l = 0; l < 4; l++)
            {
                smallLocation.Add(new Vector3(xSmall, 0, zSmall));
                u++;

                xSmall += stepS * 2;
            }

            xSmall = x - stepS * (4 - 1);
            zSmall += stepS * 2;
        }


    }
    void addTrees(float xTree, float zTree, float stepSize, int u)
    {
        for (int k = 0; k < natureDensity; k++)
        {

            for (int l = 0; l < natureDensity; l++)
            {

                //Debug.Log("Spawning  " + u + " at: " + xTree + ", " + zTree);
                tree = Instantiate(treeObject, new Vector3(xTree, 0, zTree), transform.rotation);
                //smallLocation.Add(new Vector3(xTree, 0, zTree));

                tree.transform.parent = tile.transform;
                tree.name = "Bush " + u;
                tree.tag = "Plant";
                u++;

                xTree += stepSize * 2;
            }

            xTree = x - stepSize * (natureDensity - 1);
            zTree += stepSize * 2;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
