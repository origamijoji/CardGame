using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class OnHoverDefine: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private FieldCard thisCard;
    private bool _isHovered;
    private Coroutine DefineCardRoutine;
    private GameObject _cardPreview;

    public void OnPointerEnter(PointerEventData _EventData) {
        //_isHovered = true;
        _cardPreview = Instantiate(ReferenceManager.Instance.Card);
        _cardPreview.GetComponent<HeldCard>().DisplayInfo(thisCard.BaseCard);
        _cardPreview.transform.SetParent(ReferenceManager.Instance.Table.transform);
        _cardPreview.transform.localScale = ReferenceManager.Instance.Card.transform.localScale;
        _cardPreview.transform.position = gameObject.transform.position + Vector3.right * 150;
        //DefineCardRoutine = StartCoroutine(DefineCard());
    }
    public void OnPointerExit(PointerEventData _EventData) {
        Destroy(_cardPreview);
        //_isHovered = false;
        //StopCoroutine(DefineCardRoutine);

    }


    private IEnumerator DefineCard() {

        while(true) {

        }
    }
}