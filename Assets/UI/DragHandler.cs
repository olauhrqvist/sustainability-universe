using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    // Move object to mouse position
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    // return object to original position
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.down*18;
    }
}
