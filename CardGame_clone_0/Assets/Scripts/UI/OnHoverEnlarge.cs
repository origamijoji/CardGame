using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class OnHoverEnlarge : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private float _scaleAmount;
    float maxScaleAmount = 1.4f;
    [SerializeField] private bool isCursorOverCard;
    Coroutine EnlargeCard;
    Coroutine ShrinkCard;


    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        isCursorOverCard = true;
        StartCoroutine(IncreaseCardSize());
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        isCursorOverCard = false;
    }

    public IEnumerator IncreaseCardSize() {
        while(isCursorOverCard) {
            transform.localScale = new Vector3(Mathf.Sin(Time.time) + 4, Mathf.Sin(Time.time) + 4, Mathf.Sin(Time.time) + 4);
            yield return null;
        }
    }
    private IEnumerator DecreaseCardSize() {
        while(!isCursorOverCard) {

            yield return null;
        }
    }
}