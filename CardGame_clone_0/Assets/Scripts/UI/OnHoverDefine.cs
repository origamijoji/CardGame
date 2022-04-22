using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class OnHoverDefine: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private FieldCard thisCard;
    [SerializeField] private GameObject _cardPreview;

    public void OnPointerEnter(PointerEventData _EventData) {
        _cardPreview = Instantiate(ReferenceManager.Instance.Card);
        _cardPreview.GetComponent<HeldCard>().DisplayInfo(thisCard.BaseCard);
        _cardPreview.transform.SetParent(ReferenceManager.Instance.Table.transform);
        _cardPreview.transform.localScale = ReferenceManager.Instance.Card.transform.localScale * 1.5f;
        _cardPreview.transform.position = gameObject.transform.position + Vector3.right * 200;
        Destroy(_cardPreview.GetComponent<Drag>());
        Destroy(_cardPreview.GetComponent<OnHoverEnlarge>());
        Invoke("DisablePreview", 5);
    }
    public void OnPointerExit(PointerEventData _EventData) {
        Destroy(_cardPreview);
    }

    private void DisablePreview()
    {
        if(_cardPreview != null)
        {
            Destroy(_cardPreview);
        }
    }

}