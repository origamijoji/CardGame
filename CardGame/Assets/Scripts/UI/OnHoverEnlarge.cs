using UnityEngine;
using System;

public class OnHoverEnlarge : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        Debug.Log("Cursor Entering " + name + " GameObject");
        // Lerp enlarge card
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        Debug.Log("Cursor Exiting " + name + " GameObject");
        // Lerp card to original size
    }
}