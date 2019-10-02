using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    public Color clickColor;
    private GameObject selectTile;
    private GameObject prevTile = null;
    private bool stay=false;

    void Update()
    {
        if (stay && selectTile!=null)
        {
         selectTile.GetComponent<Renderer>().material.SetColor("_Color", clickColor);
        }
    }
    void OnGUI()
    {
      if (Input.GetMouseButtonDown(0))
      {
        Debug.Log("Pressed primary button.");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {     
                if (hit.collider.gameObject.name== "OriginalPlane(Clone)")
                {
                    
                    selectTile = hit.collider.gameObject;
                    stay = true;
                    if (prevTile!=null && prevTile == selectTile)
                    {
                        //Debug.Log(prevTile);
                        //Debug.Log(selectTile); 

                    }
                    prevTile = selectTile;
                    
                }
                else
                {
                stay = false;
                }
            }
      }
    }

    




}
