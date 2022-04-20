using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinionUI : MonoBehaviour
{
    [SerializeField] private FieldCard _thisCard;
    [SerializeField] private TextMeshProUGUI _healthUI;
    [SerializeField] private TextMeshProUGUI _damageUI;
    [SerializeField] private RawImage _rawImage;

    public void UpdateUI() {
        _healthUI.text = _thisCard._health.ToString();
        _damageUI.text = _thisCard._damage.ToString();
    }
    public void SetImage() {
        _rawImage.texture = _thisCard.BaseCard.art.texture;
    }
    private void Update() {
        SetImage();
        UpdateUI();
    }

}
