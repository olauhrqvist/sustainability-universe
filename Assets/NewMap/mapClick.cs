using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapClick : MonoBehaviour
{
    public Color clickColor ;
    private GameObject selectTile = null;
    private GameObject prevTile = null;
    List<GameObject> foundObj = new List<GameObject>();
    List<GameObject> tileObjList = new List<GameObject>();
    private Color planeColor;
    private Color orginColor;
    private int i = 1;


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
                    
                    if (prevTile !=null && prevTile != selectTile)
                    {
                     
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
                    selectTile.GetComponent<Renderer>().material.color = orginColor;
                }
                else
                {
                    print("hit other things");
                    if(selectTile!=null)
                        selectTile.GetComponent<Renderer>().material.color = orginColor;
                }
                
        }
      }
    }

    




}
