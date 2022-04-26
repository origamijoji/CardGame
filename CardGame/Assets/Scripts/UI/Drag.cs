using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Coroutine ReturnCardRoutine;
    private Coroutine PlayCardRoutine;
    private int _siblingIndex;
    private GameObject _cardShadow;
    [SerializeField] private HeldCard thisCard;

    public void OnBeginDrag(PointerEventData _EventData)
    {
        // Get Values.
        if(!Player.LocalPlayer.IsTurn) { return; }
        if (_cardShadow != null) { Destroy(_cardShadow); }
        if (ReturnCardRoutine != null) { StopCoroutine(ReturnCardRoutine); }

        _siblingIndex = transform.GetSiblingIndex();
        // Remove card from parent.
        transform.SetParent(ReferenceManager.Instance.Table.transform);
        // Create dummy shadow.
        _cardShadow = Instantiate(ReferenceManager.Instance.CardShadow);
        _cardShadow.transform.SetParent(ReferenceManager.Instance.PlayerHand.transform);
        _cardShadow.transform.SetSiblingIndex(_siblingIndex);
        _cardShadow.transform.localScale = ReferenceManager.Instance.Card.transform.localScale;
        PlayCardRoutine = StartCoroutine(PlayCard());

    }
    public void OnDrag(PointerEventData _EventData)
    {
        if (!Player.LocalPlayer.IsTurn) { return; }
        gameObject.transform.position = Input.mousePosition;
        transform.localScale = ReferenceManager.Instance.Card.transform.localScale;
    }

    public void OnEndDrag(PointerEventData _EventData)
    {
        if (!Player.LocalPlayer.IsTurn) { return; }
        StopCoroutine(PlayCardRoutine);
        ReturnCardRoutine = StartCoroutine(ReturnCard());
    }

    IEnumerator PlayCard()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(1))
            {

                if (Player.LocalPlayer.Mana >= thisCard._cardInfo.manaCost)
                {
                    if (thisCard.CardType == CardType.Minion)
                    {
                        Player.LocalPlayer.PlayMinion(thisCard.CardID, thisCard._cardInfo.manaCost);
                        Destroy(_cardShadow);
                        Destroy(gameObject);
                        yield break;
                    }
                    else
                    {
                        Player.LocalPlayer.PlaySpell(thisCard.CardID, thisCard._cardInfo.manaCost);
                        Destroy(_cardShadow);
                        Destroy(gameObject);
                    }
                }
                else
                {
                    Debug.Log("Cannot afford");
                }
            }
            yield return null;
        }
    }

    IEnumerator ReturnCard()
    {
        // Lerp card back to shadow.
        while (Vector2.Distance(transform.position, _cardShadow.transform.position) > 1)
        {
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
