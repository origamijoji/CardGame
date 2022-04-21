using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool hovered;
    // Start is called before the first frame update

    public void OnPointerEnter(PointerEventData data) {
        hovered = true;
    }
    public void OnPointerExit(PointerEventData data) {
        hovered = false;
    }
}
