﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    public Color clickColor ;
    private GameObject selectTile;
    private GameObject prevTile = null;
    private bool stay=false;

    void Update()
    {
        if (stay && selectTile!=null)
        {
            
            selectTile.GetComponent<Renderer>().material.color = clickColor;
           // selectTile.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            //Debug.Log(selectTile.GetComponent<Renderer>().material.GetColor("_Color"));
        }
    }
    void OnGUI()
    {
      if (Input.GetMouseButtonDown(0))
      {
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
                
                if (hit.collider.gameObject.tag== "tile")
                {
                    //tr.Substring(0,i)
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
