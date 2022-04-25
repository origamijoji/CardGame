using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeldCard : MonoBehaviour
{
    // Composition
    public ScriptableCard _cardInfo;
    public int CardID { get; private set; }
    public CardType CardType { get; private set; }

    // Components
    [SerializeField] private Image _art;
    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _damage;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _cost;

    public void DisplayInfo(int cardID, CardType type) {
        if (type == CardType.Minion)
        {
            var minionInfo = CardList.GetMinion(cardID);
            _cardInfo = minionInfo;
            CardID = cardID;
            CardType = type;
            _health.text = minionInfo.health.ToString();
            _damage.text = minionInfo.damage.ToString();
        }
        else
        {
            var spellInfo = CardList.GetSpell(cardID);
            _cardInfo = spellInfo;
            CardID = cardID;
            CardType = type;
        }
        
        _art.sprite = _cardInfo.art;
        _name.text = _cardInfo.name.ToString();
        _description.text = _cardInfo.description.ToString();
        _cost.text = _cardInfo.manaCost.ToString();
    }

    public void DisplayInfo(ScriptableCard scriptableCard) {
        _cardInfo = scriptableCard;

        if (_cardInfo is Minion minionInfo) {
            _health.text = minionInfo.health.ToString();
            _damage.text = minionInfo.damage.ToString();
        }
        if (_cardInfo is Spell spellInfo) {

        }
        _art.sprite = _cardInfo.art;
        _name.text = _cardInfo.name.ToString();
        _description.text = _cardInfo.description.ToString();
        _cost.text = _cardInfo.manaCost.ToString();
    }
}
