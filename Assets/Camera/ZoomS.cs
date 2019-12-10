using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for the zoom handlers.
public interface ZoomS
{
  void ZoomIn(Camera cam, float delta, float nearZoomLimit);
  void ZoomOut(Camera cam, float delta, float outZoomLimit);
}
