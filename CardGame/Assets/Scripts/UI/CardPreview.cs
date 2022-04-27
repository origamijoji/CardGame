using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPreview : EntityObserver
{
    [SerializeField] private FieldCard _thisCard;
    [SerializeField] private Image _cardPreview;
    [SerializeField] private GameObject _feintPreview;


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

    public override void OnNotification()
    {
        if (_thisCard.ThisTarget == Targets.EnemyMinions) { _feintPreview.SetActive(false); SetTransparent(); return; }

        if (_thisCard.IsFeint)
        {
            _feintPreview.SetActive(true);
        }
        else
        {
            _feintPreview.SetActive(false);
        }

        if (!Player.LocalPlayer.IsTurn)
        {
            SetTransparent();
        }
        else if (_thisCard == DragAttack.CurrentAttacker)
        {
            SetMagenta();
        }
        else if (_thisCard.CanAttack)
        {
            SetGreen();
        }
        else
        {
            SetTransparent();
        }
    }
    IEnumerator waitBeforeContinue(float length)
    {
        yield return new WaitForSeconds(length);
    }

}
