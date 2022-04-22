using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerDeck : NetworkBehaviour {
    [SerializeField] private Player _player;
    [HideInInspector] public int deckSize = 30;
    [HideInInspector] public int handSize = 7;
    [SerializeField] private GameObject _blankCard;
    [SerializeField] private Transform _playerHand;

    public List<Card> deckList = new List<Card>();

    public override void OnStartClient() {
        if (!isLocalPlayer) { return; }
        _playerHand = ReferenceManager.Instance.PlayerHand.transform;
        _blankCard = ReferenceManager.Instance.Card;
    }

    public void DrawCard() {
        if (!isLocalPlayer) { return; }
        
        var newCardInfo = deckList[0];
        var newCard = Instantiate(_blankCard);
        newCard.transform.SetParent(_playerHand);
        newCard.transform.localScale = ReferenceManager.Instance.Card.transform.localScale;
        //_hand.Add(newCardInfo);
        deckList.RemoveAt(0);
        newCard.GetComponent<HeldCard>().DisplayInfo(newCardInfo.ID, newCardInfo.type);
    }
}

[System.Serializable]
public class Card
{
    public int ID;
    public CardType type;
}
