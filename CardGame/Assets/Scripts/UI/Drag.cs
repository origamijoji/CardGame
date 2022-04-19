using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    private Coroutine ReturnCard;
    private int _siblingIndex;
    private GameObject _cardShadow;

    public void OnBeginDrag(PointerEventData _EventData) {
        // Get Values.
        if (_cardShadow != null) { Destroy(_cardShadow); }
        if (ReturnCard != null) { StopCoroutine(ReturnCard); }
        _siblingIndex = transform.GetSiblingIndex();
        // Remove card from parent.
        transform.SetParent(ReferenceManager.Instance.Table.transform);
        // Create dummy shadow.
        _cardShadow = Instantiate(ReferenceManager.Instance.CardShadow);
        _cardShadow.transform.SetParent(ReferenceManager.Instance.PlayerHand.transform);
        _cardShadow.transform.SetSiblingIndex(_siblingIndex);
        _cardShadow.transform.localScale = ReferenceManager.Instance.Card.transform.localScale;
    }

    public void OnDrag(PointerEventData _EventData) {
        gameObject.transform.position = Input.mousePosition;
        transform.localScale = ReferenceManager.Instance.Card.transform.localScale;
    }

    public void OnEndDrag(PointerEventData _EventData) {
        foreach(GameObject hoverObject in _EventData.hovered) {
            Debug.Log(hoverObject);
        }
                ReturnCard = StartCoroutine(ReturnToHand());
        //if(Physics2D.Raycast(Input.mousePosition, Vector2.))
    }

    IEnumerator ReturnToHand() {
        // Lerp card back to shadow.
        while (Vector2.Distance(transform.position, _cardShadow.transform.position) > 1) {
            transform.position = Vector2.Lerp(transform.position, _cardShadow.transform.position, Time.deltaTime * 14);
            yield return null;
        }
        // Delete shadow.
        Destroy(_cardShadow);
        _cardShadow = null;
        // Set card as child.
        transform.SetParent(ReferenceManager.Instance.PlayerHand.transform);
        transform.SetSiblingIndex(_siblingIndex);
        yield break;
    }
}
