using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModelScript : MonoBehaviour
{

    public GameObject cloud1;
    public GameObject grass1;
    public GameObject grass2;
    public GameObject rock;
    public GameObject flower;

    private List<Vector3> smallLocation;
    //private List<GameObject> objects;
    private Object[] objects;

    void Start()
    {
    
        smallLocation = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().smallLocation;
        print("smallLocation count: " + smallLocation.Count);
        //objects = Resources.LoadAll("mapNatureSmall").Cast<GameObject>().ToArray();
        objects = Resources.LoadAll("Assets/mapNatureSmall");
        print("objects count: " + objects.Length);

        spawnRocks();
        spawnGrass();
        spawnFlower();
        spawnCloud();
        spawnCloud();
        /*objects.Add(Instantiate(cloud));
    objects.Add(Instantiate(grass1));
    objects.Add(Instantiate(grass2));
    objects.Add(Instantiate(rock));
    objects.Add(Instantiate(flower));
    */

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
    
    for (int i = 0; i < 10; i++)
    {
            Vector3 location = smallLocation[Random.Range(0, (smallLocation.Count)-1)];
            Instantiate(rock, location, transform.rotation);
    }

    }

    public void spawnGrass()
    {
       
        for (int i = 0; i < 10; i++)
        {
            Vector3 location = smallLocation[Random.Range(0, (smallLocation.Count) - 1)];
            Instantiate(grass1, location, transform.rotation);
        }
        for (int i = 0; i < 10; i++)
        {
            Vector3 location = smallLocation[Random.Range(0, (smallLocation.Count) - 1)];
            Instantiate(grass2, location, transform.rotation);
        }
    }

    public void spawnFlower()
    {
        
        for (int i = 0; i < 10; i++)
        {
            Vector3 location = smallLocation[Random.Range(0, (smallLocation.Count) - 1)];
            Instantiate(flower, location, transform.rotation);
        }

    }

    public void spawnCloud()
    {
       
        for (int i = 0; i < 2; i++)
        {
            Vector3 location = smallLocation[Random.Range(0, (smallLocation.Count) - 1)];
            location.y = 20;
            cloud1.transform.localScale = new Vector3(0.3f, 0.3f,0.3f);
            Instantiate(cloud1, location, transform.rotation);
        }

    }

}
