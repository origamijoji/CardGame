using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Mirror;

public class Drag : NetworkBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private float speed;

    public void DragHandler(BaseEventData data) {
        if(!isLocalPlayer) { return; }
        PointerEventData pointerData = (PointerEventData) data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out position);
        transform.position = Vector2.Lerp(transform.position, canvas.transform.TransformPoint(position), Time.deltaTime * speed);
    }

}
