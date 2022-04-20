using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAttack : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public void OnBeginDrag(PointerEventData _EventData) {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData _EventData) {
        Debug.Log("OnDrag");
    }

    public void OnEndDrag(PointerEventData _EventData) {
        Debug.Log("OnEndDrag");
    }
}