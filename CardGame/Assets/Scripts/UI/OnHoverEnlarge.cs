using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnHoverEnlarge : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler{
    [SerializeField] private float _scaleAmount;

    public void OnPointerDown(PointerEventData pointerEventData) {
        transform.localScale = ReferenceManager.Instance.Card.transform.localScale;
        LayoutRebuilder.ForceRebuildLayoutImmediate(ReferenceManager.Instance.PlayerHand.GetComponent<RectTransform>());
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        transform.localScale = ReferenceManager.Instance.Card.transform.localScale * _scaleAmount;
        LayoutRebuilder.ForceRebuildLayoutImmediate(ReferenceManager.Instance.PlayerHand.GetComponent<RectTransform>());
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        transform.localScale = ReferenceManager.Instance.Card.transform.localScale;
        LayoutRebuilder.ForceRebuildLayoutImmediate(ReferenceManager.Instance.PlayerHand.GetComponent<RectTransform>());
    }
}
