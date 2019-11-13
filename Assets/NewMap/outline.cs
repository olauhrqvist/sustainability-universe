using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outline : MonoBehaviour
{
    private float x;
    private float z;
    private float tileSize ;
    private int N ;
    public GameObject outlinePlane;
    // Start is called before the first frame update
    void Start()
    {
        tileSize = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tileSize;
        N = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().N+15 ;
        drawMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void drawMap()
    {
        
        x = (-(tileSize / 2) * ((float)N+4));
        z = (-(tileSize / 2) * ((float)N+4 ));

        for (int i = 0; i < N; i++) // x
        {
            for (int j = 0; j < N+4; j++) //y
            {
                
                Instantiate(outlinePlane, new Vector3(x, -1, z), transform.rotation);
                z += tileSize;
            }

            x += tileSize;
            z = (-(tileSize / 2) * ((float)N+4));
        }

    }
}
