using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public GameObject planeTile;

    public List<GameObject> tileMap;

    private float x = -15;
    private float z = -15;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {

                //Instantiate(planeTile, new Vector3(x, 0,  z), transform.rotation);
                //tileMap.Add(planeTile);
                tileMap.Add(Instantiate(planeTile, new Vector3(x, 0, z), transform.rotation));
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
