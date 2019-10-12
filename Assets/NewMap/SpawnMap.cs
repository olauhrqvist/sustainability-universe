using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public GameObject planeTile;

    public List<GameObject> tileMap;

    private float x = -15;
    private float z = -15;
    private GameObject tile;
    public int tileNumberNxN = 8;

    


    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        for (int i = -4; i < 4; i++)
        {
            for (int j = -4 ; j < 4 ; j++)
=======
        
        for (int i = 0; i < tileNumberNxN; i++)
        {
            for (int j = 0; j < tileNumberNxN; j++)
>>>>>>> 29b2f0e6514542af870d4daad0dea15980a60206
            {

                //Instantiate(planeTile, new Vector3(x, 0,  z), transform.rotation);
                //tileMap.Add(planeTile);
                tile = Instantiate(planeTile, new Vector3(x, 0, z), transform.rotation);
                tile.name = "Tile" + tile.transform.position;
                tile.tag = "tile";
                tileMap.Add(tile);
                
                //Debug.Log("Spawned tile at: " + x + ", " + z);
                z = z + 10;   
            }

            x = x + 10;
            z = -15;
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
