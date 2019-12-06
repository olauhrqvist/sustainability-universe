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
    private string animalInfo;
    private string tileInfo;
    private bool WindowShow = false;
    private float windowX = 0;
    private float windowY = 0;
    private float windowWidth = 220;//200
    private float windowHight = 195;//175
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
        animalInfo = "";
          globalDatabase = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().globalDatabase;
        int herbivores = globalDatabase.calculateHerbivores(selectTile.GetComponent<Collider>().name);
        int omnivores = globalDatabase.calculateOmnivores(selectTile.GetComponent<Collider>().name);
        int carnivores = globalDatabase.calculateCarnivores(selectTile.GetComponent<Collider>().name);
        int wolf = globalDatabase.calculateWolf(selectTile.GetComponent<Collider>().name);
        int shrew = globalDatabase.calculateShrew(selectTile.GetComponent<Collider>().name);
        int fox = globalDatabase.calculateFox(selectTile.GetComponent<Collider>().name);
        int weasel = globalDatabase.calculateWeasel(selectTile.GetComponent<Collider>().name);
        int squirrel = globalDatabase.calculateSquirrel(selectTile.GetComponent<Collider>().name);
        int boar = globalDatabase.calculateBoar(selectTile.GetComponent<Collider>().name);
        int rat = globalDatabase.calculateRat(selectTile.GetComponent<Collider>().name);
        int brownBear = globalDatabase.calculateBrownBear(selectTile.GetComponent<Collider>().name);
        int mouse = globalDatabase.calculateMouse(selectTile.GetComponent<Collider>().name);
        int hare = globalDatabase.calculateHare(selectTile.GetComponent<Collider>().name);
        int moose = globalDatabase.calculateMoose(selectTile.GetComponent<Collider>().name);
        int deer = globalDatabase.calculateDeer(selectTile.GetComponent<Collider>().name);

        // Herbivores
        if (mouse != 0)
            animalInfo += "Mice: " + mouse + "\r\n";
        if (hare != 0)
            animalInfo += "Hares: " + hare + "\r\n";
        if (deer != 0)
            animalInfo += "Deer: " + deer + "\r\n";
        if (moose != 0)
            animalInfo += "Moose " + moose + "\r\n";

        // Omnivores
        if (squirrel != 0)
            animalInfo += "Squirrels: " + squirrel + "\r\n";
        if (rat != 0)
            animalInfo += "Rats: " + rat +  "\r\n";
        if (boar != 0)
            animalInfo += "Boar: " + boar +  "\r\n";
        if (brownBear != 0)
            animalInfo += "Brown Bears: " + brownBear +  "\r\n";

        // Carnivores
        if (shrew != 0)
            animalInfo += "Shrews: " + shrew + "\r\n";
        if (fox != 0)
            animalInfo += "Foxes: " + fox + "\r\n";
        if (weasel != 0)
            animalInfo += "Weasels: " + weasel + "\r\n";
        if (wolf != 0)
            animalInfo += "Wolves: " + wolf + "\r\n";


        List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
        //double meat = tiles.Find(x => x.name == selectTile.GetComponent<Collider>().name).meatOnTile;
        List<double> meatlist = tiles.Find(x => x.name == selectTile.GetComponent<Collider>().name).foodHierarchy;
        double vegetation = tiles.Find(x => x.name == selectTile.GetComponent<Collider>().name).vegetationOnTile;
        int treenumber = tiles.Find(x => x.name == selectTile.GetComponent<Collider>().name).tileTrees.Count;


        string vegetationStatus;
        if (vegetation < 300)
          vegetationStatus = "Low";
        else if (vegetation < 800)
          vegetationStatus = "Medium";
        else
          vegetationStatus = "High";

        tileInfo = "Tile: " + selectTile.GetComponent<Collider>().name + "\r\n"
        + "Trees:     " + (treenumber) + "\r\n"
        + "Vegetation: " + vegetationStatus + " (" + vegetation + ")" + "\r\n"
        + animalInfo + "\r\n";
        //+ "Total food: " + "\r\n";
    }

    void MyWindow(int WindowID)
    {
        int offset = 50;
        if (windowHight + windowY > Screen.height)
            windowY = windowY - windowHight;
        if (windowWidth + windowX > Screen.width)
            windowX = windowX - windowWidth;


        GUI.Label(new Rect(10, 20, windowWidth-15, windowHight - offset), tileInfo);

        ////// Invisible(tranparent) ui button behind the gui button so the ray light can not go through the gui close button.
       // closeButton.SetActive(true);
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
