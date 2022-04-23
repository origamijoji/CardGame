using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAttack : MonoBehaviour, IPointerClickHandler
{
    public static Entity CurrentAttacker { get; set; }
    [SerializeField] private Entity thisEntity;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (CurrentAttacker != null && !thisEntity.IsLocal)
        {
            CurrentAttacker.Attack(thisEntity);
            CurrentAttacker = null;
        }
        else if (thisEntity.IsLocal && CurrentAttacker != thisEntity && thisEntity.CanAttack)
        {
            CurrentAttacker = thisEntity;
            
        }
        else if (CurrentAttacker == thisEntity)
        {
            CurrentAttacker = null;
        }
        EntitySubject.Notify();
    }
}