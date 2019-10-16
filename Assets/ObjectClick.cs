using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    public Color clickColor ;
    private GameObject selectTile = null;
    private GameObject prevTile = null;
    private bool stay=false;
    private bool newSelectedTile = false;
    List<GameObject> foundObj = new List<GameObject>();
    List<GameObject> tileObjList = new List<GameObject>();
    private Color planeColor;
    private Color orginColor;
    private int i = 1;

    /*void Update()
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
    }*/

    void findObj()
    {
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name == "TemplateModel(Clone)" || gameObj.tag == "Animal" || gameObj.tag=="Plant") 
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
        if(Physics.Raycast(ray, out hit, 100))
        {
                
                if (hit.collider.gameObject.tag== "tile")
                {
                    //tr.Substring(0,i)
                    planeColor = hit.collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
                    if (i == 1)
                    {
                        orginColor = planeColor;
                        i = 0;
                    }
                    
                    selectTile = hit.collider.gameObject;
                    stay = true;
                    
                    if (prevTile !=null && prevTile != selectTile)
                    {
                     
                        newSelectedTile = true;
                        selectTile.GetComponent<Renderer>().material.color = clickColor;
                        prevTile.GetComponent<Renderer>().material.color = orginColor;

                    }
         

                    prevTile = selectTile;
                    findObj();
                    printFoundList();
                    foundObj.Clear();
                    tileObjList.Clear();
                }
                else if (hit.collider.gameObject.tag == "Plant")
                {
                    print("hit trees");
                }
                else
                {
                    print("hit other things");
                }
                
        }
      }
    }

    




}
