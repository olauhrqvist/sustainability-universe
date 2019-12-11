using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Setting for the camera to work in perspective.
public class PerspectiveZoom : ZoomS
{
  Vector3 NormalCamPos;
  float currentZoomLvl; //where camera should be

  public PerspectiveZoom(Camera cam, Vector3 offset, float StartinZoom)
  {
    NormalCamPos = new Vector3(Mathf.Abs(offset.x), Mathf.Abs(offset.y), Mathf.Abs(offset.z)).normalized;
    currentZoomLvl = StartinZoom;
    PosCamera(cam);
  }

  private void PosCamera(Camera cam)
  {
    cam.transform.localPosition = NormalCamPos * currentZoomLvl;
  }

  public void ZoomIn(Camera cam, float delta, float nearZoomLimit)
  {
    if (currentZoomLvl <= nearZoomLimit) return;
    currentZoomLvl = Mathf.Max(currentZoomLvl - delta, nearZoomLimit);
    PosCamera(cam);
  }

  public void ZoomOut(Camera cam, float delta, float outZoomLimit)
  {
    if (currentZoomLvl >= outZoomLimit) return;
    currentZoomLvl = Mathf.Min(currentZoomLvl + delta, outZoomLimit);
    PosCamera(cam);
  }
}
