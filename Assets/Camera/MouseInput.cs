﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Mouse movement, works like an AoE camera, when you go to the top/bottom/left/right the camera starts to move.
*/
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
  public GameObject Notifications;

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

    if (mousepos.x < screen.x * .05f) /*Checks if the mouse has gone to the 5% of 1920 pixels from left to right to check if the player wants to go left with the mouse*/
    {
      OnMoveInput?.Invoke(-Vector3.forward);
    }
    else if (mousepos.x > screen.x * 0.95f) /*Checks if the mouse has gone to the 95% of 1920 pixels from left to right to check if the player wants to go right with the mouse*/
    {
      //This one checks if any of the shop tabs are active, if so the camera wont move to the right. 
      if ((mousepos.y > screen.y * 0.60f || mousepos.y < screen.y * 0.47f) && !(shoppen.activeSelf || Tree.activeSelf || Carnivores.activeSelf || Herbivores.activeSelf || plants.activeSelf || Fungus.activeSelf || Omnivores.activeSelf || Saprovores.activeSelf || EcoSystemStats.activeSelf || Notifications.activeSelf))
      {
        OnMoveInput?.Invoke(Vector3.forward);
      }
    }


    if (mousepos.y < screen.y * .05f) // Same as earlier, but this one checks the bottom of the screen.
    {
      //This one checks for the deadzones in the shop arena.
      if ((shoppen.activeSelf || Tree.activeSelf || Carnivores.activeSelf || Herbivores.activeSelf || plants.activeSelf || Fungus.activeSelf || Omnivores.activeSelf || Saprovores.activeSelf || EcoSystemStats.activeSelf || Notifications.activeSelf) && mousepos.x < screen.x * 0.85)
      {
        OnMoveInput?.Invoke(Vector3.right);
      }
      //Checks if the shop isnt active¨, then it works on the whole bottom row
      else if (!(shoppen.activeSelf || Tree.activeSelf || Carnivores.activeSelf || Herbivores.activeSelf || plants.activeSelf || Fungus.activeSelf || Omnivores.activeSelf || Saprovores.activeSelf || EcoSystemStats.activeSelf || Notifications.activeSelf))
      {
        OnMoveInput?.Invoke(Vector3.right);
      }

    }
    else if (mousepos.y > screen.y * .95f) //same as the one above but for the top of the screen
    {
      if ((shoppen.activeSelf || Tree.activeSelf || Carnivores.activeSelf || Herbivores.activeSelf || plants.activeSelf || Fungus.activeSelf || Omnivores.activeSelf || Saprovores.activeSelf || EcoSystemStats.activeSelf || Notifications.activeSelf) && mousepos.x < screen.x * 0.85)
      {
        OnMoveInput?.Invoke(-Vector3.right);
      }
      else if (!(shoppen.activeSelf || Tree.activeSelf || Carnivores.activeSelf || Herbivores.activeSelf || plants.activeSelf || Fungus.activeSelf || Omnivores.activeSelf || Saprovores.activeSelf || EcoSystemStats.activeSelf || Notifications.activeSelf))
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



    // Zoom for the map, all the statements in the if state are to check if the mouse is on the gamescreen or in the shoparea.
    if (!(shoppen.activeSelf || Tree.activeSelf || Carnivores.activeSelf || Herbivores.activeSelf || plants.activeSelf || Fungus.activeSelf || Omnivores.activeSelf || Saprovores.activeSelf || EcoSystemStats.activeSelf || Notifications.activeSelf))
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
    else if ((shoppen.activeSelf || Tree.activeSelf || Carnivores.activeSelf || Herbivores.activeSelf || plants.activeSelf || Fungus.activeSelf || Omnivores.activeSelf || Saprovores.activeSelf || EcoSystemStats.activeSelf || Notifications.activeSelf) && (mousepos.x < (screen.x * 0.87f)))
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
