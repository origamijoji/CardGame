using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public void OnBeginDrag(PointerEventData _EventData)
    {
        Debug.Log("OnBeginDrag");
        
    }
 
    public void OnDrag(PointerEventData _EventData)
    {
        Debug.Log("OnDrag");
        // set position to mouse center
    
    }
 
    public void OnEndDrag(PointerEventData _EventData)
    {
        Debug.Log("OnEndDrag");
        // if in field zone => call play card
        // else, return back to original zone
    }
    /*
    [SerializeField] private Canvas canvas;
    [SerializeField] private float speed;

    public void DragHandler(BaseEventData data) {

        PointerEventData pointerData = (PointerEventData) data;
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out position);
        transform.position = Vector2.Lerp(transform.position, canvas.transform.TransformPoint(position), Time.deltaTime * speed);
    }
    */


}
