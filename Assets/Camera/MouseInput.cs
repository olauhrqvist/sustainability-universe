using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : InputValue
{

    Vector2Int screen;
    float MousePosRotate;
    public GameObject shoppen;
    public GameObject Tree;
    public GameObject plants;
    public GameObject Fungus;
    public GameObject Carnivores;
    public GameObject Herbivores;
    public GameObject Omnivores;
    public GameObject Saprovores;
    public GameObject EcoSystemStats;

    // Events
    public static event MoveInputHandler OnMoveInput;
    public static event RotateInputHandler OnRotateInput;
    public static event ZoomInputHandler OnZoomInput;


    private void Awake()
    {
        screen = new Vector2Int(Screen.width, Screen.height);
    }

    private void Update()
    {
        Vector3 mousepos = Input.mousePosition;
        //checks if the mouse is in a valid position max +- 1% from the screen
        bool mouseVaild = (mousepos.y <= screen.y * 1.01f && mousepos.y >= screen.y * -0.01f && mousepos.x <= screen.x * 1.01f && mousepos.x >= screen.x * -0.01f);

        if (!mouseVaild) return;

        //Mouse movment

        if (mousepos.x < screen.x * .05f) //very left
        {
            OnMoveInput?.Invoke(-Vector3.forward);
        }
        else if (mousepos.x > screen.x * 0.95f) // very right
        {
            if ((mousepos.y > screen.y * 0.53f || mousepos.y < screen.y * 0.47f) && !(shoppen.activeSelf || Tree.activeSelf || Carnivores.activeSelf || Herbivores.activeSelf || plants.activeSelf || Fungus.activeSelf || Omnivores.activeSelf || Saprovores.activeSelf || EcoSystemStats.activeSelf))
            {
                OnMoveInput?.Invoke(Vector3.forward);
            }
        }


        if (mousepos.y < screen.y * .05f) //Very Bottom
        {
            if ((shoppen.activeSelf || Tree.activeSelf || Carnivores.activeSelf || Herbivores.activeSelf || plants.activeSelf || Fungus.activeSelf || Omnivores.activeSelf || Saprovores.activeSelf || EcoSystemStats.activeSelf) && mousepos.x < screen.x * 0.85)
            {
                OnMoveInput?.Invoke(Vector3.right);
            }
            else if(!(shoppen.activeSelf || Tree.activeSelf || Carnivores.activeSelf || Herbivores.activeSelf || plants.activeSelf || Fungus.activeSelf || Omnivores.activeSelf || Saprovores.activeSelf || EcoSystemStats.activeSelf))
            {
                OnMoveInput?.Invoke(Vector3.right);
            }

        }
        else if (mousepos.y > screen.y * .95f) //very Top
        {
            if ((shoppen.activeSelf || Tree.activeSelf || Carnivores.activeSelf || Herbivores.activeSelf || plants.activeSelf || Fungus.activeSelf || Omnivores.activeSelf || Saprovores.activeSelf || EcoSystemStats.activeSelf) && mousepos.x < screen.x * 0.85)
            {
                OnMoveInput?.Invoke(-Vector3.right);
            }
            else if (!(shoppen.activeSelf || Tree.activeSelf || Carnivores.activeSelf || Herbivores.activeSelf || plants.activeSelf || Fungus.activeSelf || Omnivores.activeSelf || Saprovores.activeSelf || EcoSystemStats.activeSelf))
            {
                OnMoveInput?.Invoke(-Vector3.right);
            }
        }

        //rotation
        if (Input.GetMouseButtonDown(1))
        {
            MousePosRotate = mousepos.x;

        }
        else if (Input.GetMouseButton(1))
        {
            if (mousepos.x < MousePosRotate)
            {
                OnRotateInput?.Invoke(1f);

            }
            else if (mousepos.x > MousePosRotate)
            {
                OnRotateInput?.Invoke(-1f);
            }

        }



        // Zoom
        if(!(shoppen.activeSelf || Tree.activeSelf || Carnivores.activeSelf || Herbivores.activeSelf || plants.activeSelf || Fungus.activeSelf || Omnivores.activeSelf || Saprovores.activeSelf || EcoSystemStats.activeSelf))
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                OnZoomInput?.Invoke(-9f);
            }
            else if (Input.mouseScrollDelta.y < 0)
            {
                OnZoomInput?.Invoke(9f);
            }
        }
        else if ((shoppen.activeSelf || Tree.activeSelf || Carnivores.activeSelf || Herbivores.activeSelf || plants.activeSelf || Fungus.activeSelf || Omnivores.activeSelf || Saprovores.activeSelf || EcoSystemStats.activeSelf) && (mousepos.x < (screen.x * 0.87f)))
        {
            
            if (Input.mouseScrollDelta.y > 0)
            {
                OnZoomInput?.Invoke(-9f);
            }
            else if (Input.mouseScrollDelta.y < 0)
            {
                OnZoomInput?.Invoke(9f);
            }
        }

    }




}
