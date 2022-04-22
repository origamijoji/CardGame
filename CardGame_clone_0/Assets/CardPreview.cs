using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPreview : MonoBehaviour
{
    [SerializeField] private FieldCard _thisCard;
    [SerializeField] private Image _cardPreview;
    void Update()
    {
        if(_thisCard.IsLocal == false) { return; }
        //if not current turn: return

        if(_thisCard == DragAttack.CurrentAttacker)
        {
            _cardPreview.color = Color.magenta;
        }
        else if(_thisCard.CanAttack)
        {
            _cardPreview.color = Color.green;
        }
        else
        {
            _cardPreview.color = Color.clear;
        }
    }
}
