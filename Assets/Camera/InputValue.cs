using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputValue : MonoBehaviour
{
    public delegate void MoveInputHandler(Vector3 MoveV);
    public delegate void RotateInputHandler(float rotate);
    public delegate void ZoomInputHandler(float Zoom);
}
