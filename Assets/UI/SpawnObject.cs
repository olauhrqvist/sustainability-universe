using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    //public GameObject sampleObject;

    public void AddObject(GameObject sampleObject)
    {

        transform.rotation = Quaternion.identity;

        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 1000))
        {
            Instantiate(sampleObject, hit.point, Quaternion.identity);
        }
        //Instantiate(sampleObject, hit.point, Quaternion.identity);
        
    }
}
