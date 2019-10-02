using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTop : MonoBehaviour
{
    private GameObject cube;
    private List<GameObject> mapList;

    public Color startColor;
    public Color mouseOverColor;

    void Start()
    {
        mapList = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tileMap;

    }
    void Update()
    {
        isOnTop();
    }

    public void isOnTop()
    {
       // Debug.Log("Number of tiles:" + mapList.Count);

        cube = GameObject.Find("Cube");
        Vector3 cubePos = cube.transform.position;
        //int i = 0;

        for (int i = 0; i < mapList.Count; i++)
        {

            Vector3 tilePos = mapList[i].transform.position;
            float x = tilePos.x -5f;
            float z = tilePos.z - 5f;
            float cubeX = cubePos.x;
            float cubeZ = cubePos.z;

            //Debug.Log("Cube is in position " + cubeX + ", " + cubeZ);
            //Debug.Log("Tile " + i + ": x: " + x + " - " + (x+10f) + " z: " + z + " - " + (z+10f));
            mapList[i].GetComponent<Renderer>().material.SetColor("_Color", startColor);
          

            if (x < cubeX && cubeX < (x + 10f))
            {

                if (z < cubeZ && cubeZ < (z + 10f))
                {
                   // Debug.Log("Cube is inside tile: " + i);
                   // Debug.Log("Tile " + x + ", " + z);
                    mapList[i].GetComponent<Renderer>().material.SetColor("_Color", mouseOverColor);

                }
            }

          




        }
    }
}
