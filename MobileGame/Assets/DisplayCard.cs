using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    [SerializeField] private Card _card;
    [SerializeField] private Image _art;
    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _attack;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _cost;

    private void Update() {
        DisplayInfo();
    }

    private void DisplayInfo() {
        _art.sprite = _card.art;
        _health.text = _card.health.ToString();
        _attack.text = _card.attack.ToString();
        _name.text = _card.name.ToString();
        _description.text = _card.description.ToString();
        _cost.text = _card.manaCost.ToString();
    }

}
