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
    private bool WindowShow = false; // bool of tile info window
    private float windowX = 0; //tile info window position X
    private float windowY = 0; //tile info window position Y
    private float windowWidth = 230;//tile info window width
    private float windowHight = 200;//tile info window Hight
    
    private Global_Database globalDatabase;// = new Global_Database();

   
    private void Update()
    {
        if (WindowShow)
        {
            updateTileInfo();
        }
    }

    void updateTileInfo()
    {
        // Fetch Database and caculate population for each animal type. 
        string animalInfo = "";
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

        // Append animal polulation to the tile info
        // Herbivores
        if (globalDatabase.calculateHerbivores(selectTile.GetComponent<Collider>().name) > 0)
          animalInfo += "Herbivores" + "\r\n";
        if (mouse > 0)
            animalInfo += "Mice: " + mouse + "  ";
        if (hare != 0)
            animalInfo += "Hares: " + hare + "  ";
        if (deer != 0)
            animalInfo += "Deer: " + deer + "  ";
        if (moose != 0)
            animalInfo += "Moose " + moose + "\r\n";

        // Omnivores
        if (globalDatabase.calculateOmnivores(selectTile.GetComponent<Collider>().name) > 0)
          animalInfo += "\r\n" + "Omnivores" + "\r\n";
        if (squirrel != 0)
            animalInfo += "Squirrels: " + squirrel + "  ";
        if (rat != 0)
            animalInfo += "Rats: " + rat +  "  ";
        if (boar != 0)
            animalInfo += "Boar: " + boar +  "  ";
        if (brownBear != 0)
            animalInfo += "Brown Bears: " + brownBear +  "  ";

        // Carnivores
        if (globalDatabase.calculateCarnivores(selectTile.GetComponent<Collider>().name) > 0)
          animalInfo += "\r\n" + "Carnivores" + "\r\n";
        if (shrew != 0)
            animalInfo += "Shrews: " + shrew + "  ";
        if (fox != 0)
            animalInfo += "Foxes: " + fox + "  ";
        if (weasel != 0)
            animalInfo += "Weasels: " + weasel + "  ";
        if (wolf != 0)
            animalInfo += "Wolves: " + wolf + "  ";

        // Caculate vegetation information for the tile
        List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
        double vegetation = tiles.Find(x => x.name == selectTile.GetComponent<Collider>().name).vegetationOnTile;
        int treenumber = tiles.Find(x => x.name == selectTile.GetComponent<Collider>().name).tileTrees.Count;
        //Add vegetation status to tile info
        string vegetationStatus;
        if (vegetation < 0)
          vegetationStatus = "Not enough food";
        else if (vegetation < 300)
          vegetationStatus = "Low";
        else if (vegetation < 800)
          vegetationStatus = "Medium";
        else
          vegetationStatus = "High";
        // The whole text of tile info:
        tileInfo = "Tile: " + selectTile.GetComponent<Collider>().name + "  "
        + "Trees:     " + (treenumber) + "\r\n"
        + "Vegetation: " + vegetationStatus + " (" + vegetation + ")" + "\r\n"
        + animalInfo ;
        //+ "Total food: " + "\r\n";
    }

    void MyWindow(int WindowID)
    {
        int offset = 50; // Set the offset in case the window is out of the screen. 
        if (windowHight + windowY > Screen.height)
            windowY = windowY - windowHight;
        if (windowWidth + windowX > Screen.width)
            windowX = windowX - windowWidth;

        //Tile info shown in the label here. Label is in the window. 
        GUI.Label(new Rect(10, 20, windowWidth-15, windowHight - offset), tileInfo);
        //Close button in tile info window
        if (GUI.Button(new Rect(windowWidth / 2 - windowWidth / 4, windowHight - 30, windowWidth / 2, 20), "Close"))
        { 
            WindowShow = false; // if close is pressed, the window show is false, then user can select another tile. 
            if (selectTile != null)
                selectTile.GetComponent<Renderer>().material.color = orginColor; // change the tile color to orgin color.
        }

    }
    void OnGUI()
    {
        // Mouse click event. 
        // Check the tile click only when tile info is closed. 
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && WindowShow == false)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Only check the raycast hit to the tile layer which called "MapGround". So the tile click will not hit the trees or others. 
            if (Physics.Raycast(ray, out hit, 200f, LayerMask.GetMask("MapGround"))) // Tiles have the layer "MapGround".
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
           //If a tile is selected, show the tile info window. 
            GUI.Window(0, new Rect(windowX, windowY, windowWidth, windowHight), MyWindow, "   ");
        }

    }
}
