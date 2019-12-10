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

    void Start()
    {
        tileSize = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tileSize;
        N = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().N*2 ;
        if (N <= 10)
            N = 10;
        drawMap();
    }

    void drawMap()
    {
        
        x = (-(tileSize / 2) * ((float)N+N));
        z = (-(tileSize / 2) * ((float)N+N ));

        for (int i = 0; i < N+N; i++) // x
        {
            for (int j = 0; j < N+N; j++) //y
            {
                
                Instantiate(outlinePlane, new Vector3(x, -0.5f, z), transform.rotation);
                z += tileSize;
            }

            x += tileSize;
            z = (-(tileSize / 2) * ((float)N+N));
        }

    }
}
