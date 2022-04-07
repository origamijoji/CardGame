using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class OnHoverDescribe : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Debug.Log("Cursor Entering " + name + " GameObject");
        // instantiate card that this object belongs to next to this object
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Debug.Log("Cursor Exiting " + name + " GameObject");
        // remove card object 
    }

    private void GetApexParent(PointerEventData data) {
        //Recursive case: if object is a child, call GetParent(parent)
        //Base case: object has no more parents, return gameobject
    }
}