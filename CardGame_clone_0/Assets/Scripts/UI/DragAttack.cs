using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAttack : MonoBehaviour, IPointerClickHandler
{
    //public static bool CurrentAttacker;
    public static FieldCard CurrentAttacker { get; set; }
    [SerializeField] private FieldCard thisCard;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(CurrentAttacker != null && !thisCard.IsLocal)
        {
            CurrentAttacker.Attack(thisCard);
        }
        else if(thisCard.IsLocal)
        {
            CurrentAttacker = thisCard;
        }
        else if(CurrentAttacker == thisCard)
        {
            CurrentAttacker = null;
        }
    }
}