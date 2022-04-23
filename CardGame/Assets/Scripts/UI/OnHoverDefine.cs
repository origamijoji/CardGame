using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class OnHoverDefine: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private FieldCard thisCard;
    [SerializeField] public GameObject CardPreview { get; set; }

    public void OnPointerEnter(PointerEventData _EventData) {
        CardPreview = Instantiate(ReferenceManager.Instance.Card);
        CardPreview.GetComponent<HeldCard>().DisplayInfo(thisCard.BaseCard);
        CardPreview.transform.SetParent(ReferenceManager.Instance.CardPreviews.transform);
        CardPreview.transform.localScale = ReferenceManager.Instance.Card.transform.localScale * 1.5f;
        CardPreview.transform.position = gameObject.transform.position + Vector3.right * 200;
        Destroy(CardPreview.GetComponent<Drag>());
        Destroy(CardPreview.GetComponent<OnHoverEnlarge>());
    }
    public void OnPointerExit(PointerEventData _EventData) {
        foreach(Transform item in ReferenceManager.Instance.CardPreviews.transform)
        {
            Destroy(item.gameObject);
        }
    }
}