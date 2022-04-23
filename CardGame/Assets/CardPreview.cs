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
            SetMagenta();
        }
        else if(_thisCard.CanAttack)
        {
            SetGreen();
        }
        else
        {
            SetTransparent();
        }
    }

    public void SetGreen()
    {
        _cardPreview.color = Color.green;
    }

    public void SetMagenta()
    {
        _cardPreview.color = Color.magenta;
    }

    public void SetTransparent()
    {
        _cardPreview.color = Color.clear;
    }
}
