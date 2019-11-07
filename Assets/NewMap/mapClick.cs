using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mapClick : MonoBehaviour
{
    public Color clickColor;
    private GameObject selectTile = null;
    private GameObject prevTile = null;
    List<GameObject> foundObj = new List<GameObject>();
    List<GameObject> tileObjList = new List<GameObject>();
    private Color planeColor;
    private Color orginColor;
    private int i = 1;
    private string tileInfo;
    private bool WindowShow = false;
    private float windowX = 0;
    private float windowY = 0;
    private float windowWidth = 150;
    private float windowHight = 150;
    private Dictionary<string, int> objDic = new Dictionary<string, int>();
    private int plantCount = 0;
    private int animalCount = 0;


    void findObj()
    {
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name == "TemplateModel(Clone)" || gameObj.tag == "Animal" || gameObj.tag == "Plant")
            {
                foundObj.Add(gameObj);

            }
        }

    }

    void printFoundList()
    {
        string dicInfo = "";
        foreach (var obj in foundObj)
        {
            if (selectTile.GetComponent<Collider>().bounds.Contains(obj.transform.position))
                tileObjList.Add(obj);
        }
        //print("In this tile, there are: " + tileObjList.Count + " objects.");
        foreach (var obj in tileObjList)
        {
            if (obj.tag == "Plant")
                plantCount++;
            if (obj.tag == "Animal")
                animalCount++;
            if (!objDic.ContainsKey(obj.name))
            {
                objDic.Add(obj.name, 1);
            }
            else
            {
                objDic[name]++;
            }


        }

        foreach (KeyValuePair<string, int> kvp in objDic)
        {

            dicInfo += kvp.Key + " " + kvp.Value + "\r\n";
        }

        tileInfo = "Total obj " + tileObjList.Count + "\r\n" + "Plant: " + plantCount + "  " + "Animal: " + animalCount + "\r\n" + dicInfo;

    }

    void MyWindow(int WindowID)
    {
        int offset = 50;
        if (windowHight + windowY > Screen.height)
            windowY = windowY - windowHight;
        if (windowWidth + windowX > Screen.width)
            windowX = windowX - windowWidth;
        GUI.Label(new Rect(10, 20, windowWidth, windowHight - offset), tileInfo);
        if (GUI.Button(new Rect(windowWidth / 2 - windowWidth / 4, windowHight - 30, windowWidth / 2, 20), "Close"))
        {
            print("Close Tile Info");
            WindowShow = false;
        }
    }
    void OnGUI()
    {
        
      
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {


            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 200f))
            {
                if (hit.collider.gameObject.tag == "tile")
                {
                    //tr.Substring(0,i)
                    WindowShow = true;
                    windowX = Input.mousePosition.x;
                    windowY = Screen.height - Input.mousePosition.y;
                    planeColor = hit.collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
                    if (i == 1)
                    {
                        orginColor = planeColor;
                        i = 0;
                    }

                    selectTile = hit.collider.gameObject;

                    if (prevTile != null && prevTile != selectTile)
                    {

                        selectTile.GetComponent<Renderer>().material.color = clickColor;
                        prevTile.GetComponent<Renderer>().material.color = orginColor;
                    }

                    prevTile = selectTile;
                    findObj();
                    printFoundList();
                    foundObj.Clear();
                    tileObjList.Clear();
                    objDic.Clear();
                    animalCount = 0;
                    plantCount = 0;
                }
                else if (hit.collider.gameObject.tag == "Plant")
                {
                    WindowShow = false;
                    print("hit trees");
                    if (selectTile != null)
                        selectTile.GetComponent<Renderer>().material.color = orginColor;
                }
                else
                {
                    WindowShow = false;
                    print("hit other things");
                    if (selectTile != null)
                        selectTile.GetComponent<Renderer>().material.color = orginColor;
                }

            }
        }
        if (WindowShow)
            GUI.Window(0, new Rect(windowX, windowY, windowWidth, windowHight), MyWindow, "   ");
    }
}
