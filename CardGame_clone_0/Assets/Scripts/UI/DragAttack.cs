using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAttack : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    //variable storing current fieldcard

    public void OnBeginDrag(PointerEventData _EventData) {
        Debug.Log("OnBeginDrag");
        // display arrow
    }

    public void OnDrag(PointerEventData _EventData) {
        Debug.Log("OnDrag");
        // add arrow segments
    }

    public void OnEndDrag(PointerEventData _EventData) {
        Debug.Log("OnEndDrag");
        // remove arrow
    }
}