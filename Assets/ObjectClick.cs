using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    // Update is called once per frame
    void OnGUI()
    {
      if (Input.GetMouseButtonDown(0))
      {
        Debug.Log("Pressed primary button.");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 100.0f))
        {
          if(hit.transform)
          {
          Debug.Log(hit.transform.gameObject.name);
          }
        }
      }
    }

}
