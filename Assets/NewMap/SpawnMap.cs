using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int natureDensity;
    public List<GameObject> tileMap;
    public List<Vector3> smallLocation;


    // Start is called before the first frame update
    void Start()
    {
        x = (-(tileSize/2) * ((float)N-1));
        z = (-(tileSize/2) * ((float)N-1));
        int u = 0;

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                tile = Instantiate(planeTile, new Vector3(x, 0, z), transform.rotation);
                //planeColor = new Color(107f, 141f, 75f);
                tile.GetComponent<Renderer> ().material.color = planeColor;


                float stepSize = (tileSize/(natureDensity * 2));
                float xTree = x - stepSize * (natureDensity - 1);
                float zTree = z - stepSize * (natureDensity - 1);
                //Debug.Log("Spawned tile at: " + "0 > " + x + ", 0 > " + z);
                //Debug.Log("Stepsize: " + stepSize);
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
    void addTrees(float xTree, float zTree, float stepSize, int u)
    {
        for (int k = 0; k < natureDensity; k++)
        {

            for (int l = 0; l < natureDensity; l++)
            {

                //Debug.Log("Spawning  " + u + " at: " + xTree + ", " + zTree);
                tree = Instantiate(treeObject, new Vector3(xTree, 0, zTree), transform.rotation);
                smallLocation.Add(new Vector3(xTree, 0, zTree));

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
