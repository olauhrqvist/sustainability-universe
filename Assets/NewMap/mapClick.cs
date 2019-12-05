using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mapClick : MonoBehaviour
{
    public Color clickColor;
    private GameObject selectTile = null;
    private Color planeColor;
    private Color orginColor;
    private int i = 1;
    private string tileInfo;
    private bool WindowShow = false;
    private float windowX = 0;
    private float windowY = 0;
    private float windowWidth = 250;//200
    private float windowHight = 200;//175
    private GameObject closeButton;
    private Global_Database globalDatabase;// = new Global_Database();

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

    private void Update()
    {
        if (WindowShow)
        {
            updateTileInfo();
        }
    }

    void updateTileInfo()
    {
      // Fetch Database
        globalDatabase = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().globalDatabase;
        int herbivores = globalDatabase.calculateHerbivores(selectTile.GetComponent<Collider>().name);
        int omnivores = globalDatabase.calculateOmnivores(selectTile.GetComponent<Collider>().name);
        int carnivores = globalDatabase.calculateCarnivores(selectTile.GetComponent<Collider>().name);


        List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
        //double meat = tiles.Find(x => x.name == selectTile.GetComponent<Collider>().name).meatOnTile;
        List<double> meatlist = tiles.Find(x => x.name == selectTile.GetComponent<Collider>().name).foodHierarchy;
        double vegetation = tiles.Find(x => x.name == selectTile.GetComponent<Collider>().name).vegetationOnTile;
        int treenumber = tiles.Find(x => x.name == selectTile.GetComponent<Collider>().name).tileTrees.Count;

        //Debug.Log("Tile:" + selectTile.GetComponent<Collider>().name + " " + meat);

        tileInfo = "Tile: " + selectTile.GetComponent<Collider>().name + "\r\n"
        + "Tree:     " + (treenumber) + "\r\n"
        + "Herbivores: " + (herbivores) + "\r\n"
        + "Omnivores: " + (omnivores) + "\r\n"
        + "Carnivores: " + (carnivores) + "\r\n"
        //+ "meatlist[0]" + meatlist[] + "\r\n"
        + "Meat available: [" + meatlist[0] + "] [" + meatlist[1] + "] [" + meatlist[2] + "] [" + meatlist[3] + "] [" + meatlist[4] + "]" +  "\r\n"
        + "Vegetation available: " + (vegetation) + "\r\n";
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

            //print("Close Tile Info");
            WindowShow = false;
            closeButton.SetActive(false);
            if (selectTile != null)
                selectTile.GetComponent<Renderer>().material.color = orginColor;
        }

    }
    void OnGUI()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && WindowShow == false)
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

                    planeColor = hit.collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
                    selectTile = hit.collider.gameObject;
                    if (i == 1)
                    {
                        orginColor = planeColor;
                        i = 0;
                        selectTile.GetComponent<Renderer>().material.color = clickColor;
                    }


                    selectTile.GetComponent<Renderer>().material.color = clickColor;



                }

            }
        }
        if (WindowShow)
        {
           // updateTileInfo();
            GUI.Window(0, new Rect(windowX, windowY, windowWidth, windowHight), MyWindow, "   ");
        }

    }
}
