using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : InputValue
{

    Vector2Int screen;
    float MousePosRotate;

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
            OnMoveInput?.Invoke(Vector3.forward);
        }


        if (mousepos.y < screen.y * .05f) //Very Top
        {
            OnMoveInput?.Invoke(Vector3.right);
        }
        else if (mousepos.y > screen.y * .95f) //very bottom
        {
            OnMoveInput?.Invoke(-Vector3.right);
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
