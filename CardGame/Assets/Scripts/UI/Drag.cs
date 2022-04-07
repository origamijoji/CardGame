using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    Coroutine ReturnCard;
    int siblingIndex;
    GameObject cardShadow;

    public void OnBeginDrag(PointerEventData _EventData) {
        // Get Values.
        if (cardShadow != null) { Destroy(cardShadow); }
        if (ReturnCard != null) { StopCoroutine(ReturnCard); }
        siblingIndex = transform.GetSiblingIndex();
        // Remove card from parent.
        transform.SetParent(ReferenceManager.Instance.Table.transform);
        // Create dummy shadow.
        cardShadow = Instantiate(ReferenceManager.Instance.CardShadow);
        cardShadow.transform.SetParent(ReferenceManager.Instance.PlayerHand.transform);
        cardShadow.transform.SetSiblingIndex(siblingIndex);
    }

    public void OnDrag(PointerEventData _EventData) {
        gameObject.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData _EventData) {
        ReturnCard = StartCoroutine(ReturnToHand());
    }

    IEnumerator ReturnToHand() {
        // Lerp card back to shadow.
        while (Vector2.Distance(transform.position, cardShadow.transform.position) > 1) {
            transform.position = Vector2.Lerp(transform.position, cardShadow.transform.position, Time.deltaTime * 14);
            yield return null;
        }
        // Delete shadow.
        Destroy(cardShadow);
        cardShadow = null;
        // Set card as child.
        transform.SetParent(ReferenceManager.Instance.PlayerHand.transform);
        transform.SetSiblingIndex(siblingIndex);
        yield break;
    }
}
