using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Camera Position")]
    public Vector3 CameraOffset = new Vector3(10f, 14f, 10f);
    public float LookAtOffset = 2f;

    [Header("Movement Controls")]
    public float inOutSpeed = 5f;
    public float lateralSpeed = 5f;
    public float rotateSpeed = 45f;

    [Header("Movement Bounds")]
    public Vector2 minBounds, maxBounds;

    [Header("Zoom Controls")]
    public float zoomspeed = 4f;
    public float nearZoomLimit = 2f;
    public float outZoomLimit = 16f;
    public float StartingZoom = 5f;

    Vector3 frameMove;
    float frameRotate;
    float frameZoom;

    Camera cam;
    ZoomS ZoomStrategy;



    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        cam.transform.localPosition = new Vector3(Mathf.Abs(CameraOffset.x), Mathf.Abs(CameraOffset.y), Mathf.Abs(CameraOffset.z));
      //  ZoomStrategy = new OrthographicZoom(cam, StartingZoom);
        
        ZoomStrategy = cam.orthographic ? (ZoomS)new OrthographicZoom(cam, StartingZoom) : new PerspectiveZoom(cam, CameraOffset, StartingZoom);
        //Is the camera set in orthographic or perspetive view


        cam.transform.LookAt(transform.position + Vector3.up * LookAtOffset);
    }

    private void OnEnable()
    {
        KeyboardInput.OnMoveInput += UpdateFrameMove;
        KeyboardInput.OnRotateInput += UpdateFrameRotate;
        KeyboardInput.OnZoomInput += UpdateFrameZoom;

        MouseInput.OnMoveInput += UpdateFrameMove;
        MouseInput.OnRotateInput += UpdateFrameRotate;
        MouseInput.OnZoomInput += UpdateFrameZoom;

    }

    private void OnDisable()
    {
        KeyboardInput.OnMoveInput -= UpdateFrameMove;
        KeyboardInput.OnRotateInput -= UpdateFrameRotate;
        KeyboardInput.OnZoomInput -= UpdateFrameZoom;

        MouseInput.OnMoveInput -= UpdateFrameMove;
        MouseInput.OnRotateInput -= UpdateFrameRotate;
        MouseInput.OnZoomInput -= UpdateFrameZoom;
    }


    private void UpdateFrameMove(Vector3 MoveV)
    {
        frameMove += MoveV;
    }
    private void UpdateFrameRotate(float rotate)
    {
        frameRotate += rotate;
    }
    private void UpdateFrameZoom(float Zoom)
    {
        frameZoom += Zoom;
    }


    private void LateUpdate()
    {
        if (frameMove != Vector3.zero)
        {
            Vector3 speedModFrameMove = new Vector3(frameMove.x * lateralSpeed, frameMove.y, frameMove.z * inOutSpeed);
            transform.position += transform.TransformDirection(speedModFrameMove * Time.deltaTime);
            LockPositionInBounds();
            frameMove = Vector3.zero;
        }
        if ( frameRotate != 0f)
        {
            transform.Rotate(Vector3.up, frameRotate * Time.deltaTime * rotateSpeed);
            frameRotate = 0f;
        }

        if ( frameZoom < 0f)
        {
            ZoomStrategy.ZoomIn(cam, Time.deltaTime * Mathf.Abs(frameZoom) * zoomspeed, nearZoomLimit);
            frameZoom = 0f;
        }
        else if ( frameZoom > 0f)
        {
            ZoomStrategy.ZoomOut(cam, Time.deltaTime * frameZoom * zoomspeed, outZoomLimit);
            frameZoom = 0f;
        }

    }

    private void LockPositionInBounds()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x), transform.position.y, 
                                                        Mathf.Clamp(transform.position.z, minBounds.y, maxBounds.y));
    }
}
