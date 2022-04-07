using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeldCard : MonoBehaviour
{
    // Composition
    public ScriptableCard _cardInfo;

    //reference to OnHoverEnlarge component on same prefab

    // Components
    [SerializeField] private Image _art;
    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _attack;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _cost;

    // public void ChangeCard(CardInfo cardInfo) {
    //      _cardInfo = cardInfo;
    //     DisplayInfo();
    // }
    private void Update() {
        DisplayInfo();
    }

    private void DisplayInfo() {
        if(_cardInfo is Minion _minionInfo) {
            _health.text = _minionInfo.health.ToString();
            _attack.text = _minionInfo.attack.ToString();
        }
        if(_cardInfo is Spell _spellInfo) {

        }
        _art.sprite = _cardInfo.art;
        _name.text = _cardInfo.name.ToString();
        _description.text = _cardInfo.description.ToString();
        _cost.text = _cardInfo.manaCost.ToString();
    }

}
