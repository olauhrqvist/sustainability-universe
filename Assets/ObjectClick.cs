using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
        print("Pressed primary button.");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 100.0f))
        {
          if(hit.transform)
          {
            print(hit.transform.gameObject);
          }
        }
      }
    }

}
