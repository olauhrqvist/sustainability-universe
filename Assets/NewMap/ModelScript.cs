using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModelScript : MonoBehaviour
{
    public GameObject mountain1;
    public GameObject mountain2;
    public GameObject cloud1;
    public GameObject grass1;
    public GameObject grass2;
    public GameObject rock;
    public GameObject flower;

    private float x;
    private float z;
    private List<Vector3> smallLocation;
    private int mapSizeN;
    private float tileSize = 10;// also in "SpawnMap.cs"
    private Object[] objects;
    //private List<GameObject> objects;

    void Start()
    {
        mapSizeN = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().N;
        smallLocation = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().smallLocation;

        //smallLocationTest();

        spawnRocks();
        spawnGrass();
        spawnFlower();
        spawnCloud();
        spawnCloud();
        spwanMountain();
       

        /*objects = Resources.LoadAll("mapNatureSmall").Cast<GameObject>().ToArray();
        objects = Resources.LoadAll("Assets/mapNatureSmall");
        print("objects count: " + objects.Length);*/

        /*objects.Add(Instantiate(cloud));
        objects.Add(Instantiate(grass1));
        objects.Add(Instantiate(grass2));
        objects.Add(Instantiate(rock));
        objects.Add(Instantiate(flower));
        */

    }


    public void smallLocationTest() 
    {
        for (int i = 0; i < smallLocation.Count; i++)
        {
            Vector3 location = smallLocation[i];
            Instantiate(grass1, location, transform.rotation);
        }
    }

    public void plainSpace()
    {


    }

    public void pineTreeForest()
    {



    }

    public void leafyTreeForest()
    {



    }

    public void waterBody()
    {



    }

    public void spawnRocks()
    {
        int Num = (mapSizeN / 10) * 10;
        for (int i = 0; i < Num; i++)
        {
                Vector3 location = smallLocation[Random.Range(0, (smallLocation.Count)-1)];
                Instantiate(rock, location, transform.rotation);
        }

    }

    public void spawnGrass()
    {
        int Num = (mapSizeN / 10) * 10;
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
        int Num = (mapSizeN/10)*10;
        for (int i = 0; i < Num; i++)
        {
            Vector3 location = smallLocation[Random.Range(0, (smallLocation.Count) - 1)];
            Instantiate(flower, location, transform.rotation);
        }

    }

    public void spawnCloud()
    {
        int cloudNum = mapSizeN / 3; 
        for (int i = 0; i < cloudNum; i++)
        {
            Vector3 location = smallLocation[Random.Range(0, (smallLocation.Count) - 1)];
            location.y = 20;
            cloud1.transform.localScale = new Vector3(0.5f, 0.5f,0.5f);
            Instantiate(cloud1, location, transform.rotation);
        }

    }

    public void spwanMountain()
    {
        if (mapSizeN < 4)
            return;

        x = (-(tileSize / 2) * ((float)mapSizeN - 1));
        z = (-(tileSize / 2) * ((float)mapSizeN - 1));
    
        for (int i = 0; i < mapSizeN; i++)
        {
            for(int j = 0; j < mapSizeN; j++)
            {
                if (i == mapSizeN / 2 && j == 0)
                {
                    mountain1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    Instantiate(mountain1, new Vector3(x, 0, z - (tileSize * 2)), transform.rotation);
                }

                if (i == 0 && j == mapSizeN / 2)
                {
                    mountain2.transform.localScale = new Vector3(0.4f, 0.45f, 0.4f);
                    Instantiate(mountain2, new Vector3(x - (tileSize * 4), 0, z), transform.rotation);
                }
                if(mapSizeN > 9)
                {
                    if (i == mapSizeN - 1 && j ==0 )
                    {
                        mountain1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Instantiate(mountain1, new Vector3(x, 0, z - (tileSize * 2)), transform.rotation);
                    }
                    if (i == 0 && j == 0)
                    {
                        mountain1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Instantiate(mountain1, new Vector3(x + (tileSize * 2), 0, z - (tileSize * 2)), transform.rotation);

                        mountain2.transform.localScale = new Vector3(0.45f, 0.45f, 0.45f);
                        Instantiate(mountain2, new Vector3(x - (tileSize * 4), 0, z - tileSize), transform.rotation);
                    }
                    if (i == 0 && j == mapSizeN - 1)
                    {
                        mountain2.transform.localScale = new Vector3(0.45f, 0.5f, 0.45f);
                        Instantiate(mountain2, new Vector3(x - (tileSize * 4), 0, z), transform.rotation);
                    }
                }
                
                z += tileSize;
            }
            x += tileSize;
            z = (-(tileSize / 2) * ((float)mapSizeN - 1));
        }
        
    }

}
