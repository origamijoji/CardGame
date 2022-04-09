using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeldCard : MonoBehaviour
{
    // Composition
    public ScriptableCard _cardInfo;

    // Components
    [SerializeField] private Image _art;
    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _attack;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _cost;

    public void DisplayInfo(int cardID) {
        _cardInfo = CardList.GetCard(cardID);

        if(_cardInfo is Minion minionInfo) {
            _health.text = minionInfo.health.ToString();
            _attack.text = minionInfo.attack.ToString();
        }
        if(_cardInfo is Spell spellInfo) {

        }
        _art.sprite = _cardInfo.art;
        _name.text = _cardInfo.name.ToString();
        _description.text = _cardInfo.description.ToString();
        _cost.text = _cardInfo.manaCost.ToString();
    }

}
