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
    private Color planeColor;

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
        if(Physics.Raycast(ray, out hit))
        {
                
                if (hit.collider.gameObject.tag== "tile")
                {
                    //tr.Substring(0,i)
                    planeColor = hit.collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
                    selectTile = hit.collider.gameObject;
                    stay = true;
                    
                    if (prevTile!=null && prevTile != selectTile)
                    {
                        newSelectedTile = true;
                        selectTile.GetComponent<Renderer>().material.color = clickColor;
                        prevTile.GetComponent<Renderer>().material.color = planeColor;
                        //print("prevTile != selectTile: " + newSelectedTile);
                    }else if(prevTile != null && prevTile == selectTile)
                    {
                        selectTile.GetComponent<Renderer>().material.color = planeColor;
                    }
                    

                    prevTile = selectTile;
                    findObj();
                    printFoundList();
                    foundObj.Clear();
                    tileObjList.Clear();
                }
                else
                {
                    print("click on other thing than tile"); // funkar inte med andra obj :( 
                    if (prevTile!=null)
                    {
                        prevTile.GetComponent<Renderer>().material.color = planeColor;
                    }
                //stay = false;
                }
            }
      }
    }

    




}
