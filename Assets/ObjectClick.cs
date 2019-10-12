using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    public Color clickColor ;
    private GameObject selectTile;
    private GameObject prevTile = null;
    private bool stay=false;
    private bool newSelectedTile = false;
    List<GameObject> foundObj = new List<GameObject>();
    List<GameObject> tileObjList = new List<GameObject>();

    void Update()
    {
        if (stay && selectTile!=null)
        {
            findObj();
            selectTile.GetComponent<Renderer>().material.color = clickColor;

            //print(selectTile.GetComponent<Collider>().bounds.Contains(GameObject.Find("Cube").transform.position));
            // selectTile.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            //Debug.Log(selectTile.GetComponent<Renderer>().material.GetColor("_Color"));
            if (newSelectedTile == true)
            {
                printFoundList();
            }
            foundObj.Clear();
            tileObjList.Clear();
            newSelectedTile = false;
        }
    }

    void findObj()
    {
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name == "TemplateModel(Clone)") // I want all animal/plant obj have tag "dispalyerbal" or other
            {
                foundObj.Add(gameObj);

            }
        }

    }

    void printFoundList()
    {
        foreach (var obj in foundObj)
        {
            if (selectTile.GetComponent<Collider>().bounds.Contains(obj.transform.position))
                tileObjList.Add(obj);
        }
        print("In this tile, there are: " + tileObjList.Count + " objects.");
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
                    
                    if (prevTile!=null && prevTile != selectTile)
                    {
                        newSelectedTile = true;
                        //print("prevTile != selectTile: " + newSelectedTile);
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
