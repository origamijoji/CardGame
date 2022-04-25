using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinionUI : EntityObserver
{
    [SerializeField] private FieldCard _thisCard;
    [SerializeField] private TextMeshProUGUI _healthUI;
    [SerializeField] private TextMeshProUGUI _damageUI;
    [SerializeField] private Image _image;

    public void UpdateUI()
    {
        _healthUI.text = _thisCard.Health.ToString();
        _damageUI.text = _thisCard.Damage.ToString();
    }
    public void SetImage()
    {
        _image.sprite = _thisCard.BaseCard.art;
    }

    public override void OnNotification()
    {
        UpdateUI();
    }

}
