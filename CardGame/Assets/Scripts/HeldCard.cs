using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeldCard : MonoBehaviour
{
    // Composition
    [SerializeField] private CardInfo _cardInfo;

    // Components
    [SerializeField] private Image _art;
    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _attack;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _cost;

    private void Update() {
        DisplayInfo();
    }

    public void ChangeCard(CardInfo cardInfo) {
        _cardInfo = cardInfo;
        DisplayInfo();
    }


    private void DisplayInfo() {
        _art.sprite = _cardInfo.Art;
        _health.text = _cardInfo.Health.ToString();
        _attack.text = _cardInfo.Attack.ToString();
        _name.text = _cardInfo.Name.ToString();
        _description.text = _cardInfo.Description.ToString();
        _cost.text = _cardInfo.ManaCost.ToString();
    }

}
