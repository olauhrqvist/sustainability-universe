using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
    private float windowWidth = 180;
    private float windowHight = 150;
    private Dictionary<string, int> objDic = new Dictionary<string, int>();
    private int plantCount = 0;
    private int animalCount = 0;
    private GameObject closeButton;


    private void Awake()
    {
        // ui button
        closeButton = GameObject.Find("TileInfoClose");
        closeButton.GetComponent<Image>().color = Color.clear;
        closeButton.GetComponentInChildren<Text>().text = "";
        closeButton.SetActive(false);
    }


    private void Start()
    {
        // ui button
        closeButton = GameObject.Find("TileInfoClose");
        closeButton.GetComponent<Image>().color = Color.clear;
        closeButton.GetComponentInChildren<Text>().text = "";
        closeButton.SetActive(false);
    }
    void findObj()
    {
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name == "TemplateModel(Clone)" || gameObj.tag == "Animal" || gameObj.tag == "Plant" || gameObj.name == "rpgpp_lt_tree_pine_01(Clone)")
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
                objDic[obj.name]++;
            }
        }

        foreach (KeyValuePair<string, int> kvp in objDic)
        {

            dicInfo += kvp.Key + ": " + kvp.Value + "\r\n";
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
      
        GUI.Label(new Rect(10, 20, windowWidth-10, windowHight - offset), tileInfo);

        ////// Invisible(tranparent) ui button behind the gui button so the ray light can not go through the gui close button. 
        closeButton.SetActive(true);
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        closeButton.GetComponent<RectTransform>().sizeDelta = new Vector2(windowWidth / 3, 20);
        closeButton.transform.position = pos;
        //////
        ///
        if (GUI.Button(new Rect(windowWidth / 2 - windowWidth / 4, windowHight - 30, windowWidth / 2, 20), "Close"))
        {
            
            print("Close Tile Info");
            WindowShow = false;
            closeButton.SetActive(false);
            if (selectTile != null)
                selectTile.GetComponent<Renderer>().material.color = orginColor;
        }
        
    }
    void OnGUI()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 200f, LayerMask.GetMask("MapGround")))
            {
                if (hit.collider.gameObject.tag == "tile")
                {
                    //tile info window position
                    WindowShow = true;
                    windowX = Input.mousePosition.x;
                    windowY = Screen.height - Input.mousePosition.y;
                    
                    //

                    planeColor = hit.collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
                    selectTile = hit.collider.gameObject;
                    if (i == 1)
                    {
                        orginColor = planeColor;
                        i = 0;
                        selectTile.GetComponent<Renderer>().material.color = clickColor;
                    }

                    
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
        {
            GUI.Window(0, new Rect(windowX, windowY, windowWidth, windowHight), MyWindow, "   ");
        }
            
    }
}
