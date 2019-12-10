using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Settings for the camera to work in Orthographic mode. 
public class OrthographicZoom : ZoomS
{
  public OrthographicZoom(Camera Cam, float StartingZoom)
  {
    Cam.orthographicSize = StartingZoom;
  }


  public void ZoomIn(Camera cam, float delta, float nearZoomLimit)
  {
    if (cam.orthographicSize == nearZoomLimit) return;
    cam.orthographicSize = Mathf.Max(cam.orthographicSize - delta, nearZoomLimit);
    Debug.Log(cam.orthographicSize);
  }

  public void ZoomOut(Camera cam, float delta, float outZoomLimit)
  {

    if (cam.orthographicSize == outZoomLimit) return;
    cam.orthographicSize = Mathf.Min(cam.orthographicSize + delta, outZoomLimit);
    Debug.Log(cam.orthographicSize);
  }


}
