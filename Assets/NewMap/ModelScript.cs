using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelScript : MonoBehaviour
{

    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;
    public GameObject Object4;
    public GameObject Object5;

    private List<Vector3> smallLocation;
    private List<GameObject> objects;

    void Start()
    {
    
    smallLocation = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().smallLocation;

    objects.Add(Object1);
    objects.Add(Object2);
    objects.Add(Object3);
    objects.Add(Object4);
    objects.Add(Object5);

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

    Debug.Log("Working!");


    for (int i = 0; i < 10; i++)
    {
    //Instantiate(Object1, smallLocation[Random.Range(0, smallLocation.Capacity)], transform.rotation);
    }

    }

}
