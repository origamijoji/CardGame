using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerDeck : NetworkBehaviour {
    [SerializeField] private Player _player;
    [HideInInspector] public int deckSize = 30;
    [HideInInspector] public int handSize = 7;
    [SerializeField] private GameObject _blankCard;
    [SerializeField] private Transform _playerHand;
    public ScriptableCard testCard;

    public override void OnStartClient() {
        if (!isLocalPlayer) { return; }

        base.OnStartClient();
        _playerHand = ReferenceManager.Instance.PlayerHand.transform;
        _blankCard = ReferenceManager.Instance.Card;
        for (int i = 30; i > 0; i--) {
        }
    }

    public readonly SyncableCardList _deckList = new SyncableCardList();
    public readonly SyncableCardList _deck = new SyncableCardList();
    public readonly SyncableCardList _graveyard = new SyncableCardList();
    public readonly SyncableCardList _hand = new SyncableCardList();

    public void ImportDeck() {

    }

    public void DrawCard() {
        var newCardInfo = _deck[1];
        var newCard = Instantiate(_blankCard);
        newCard.transform.SetParent(_playerHand);
        _hand.Add(newCardInfo);
        _deck.RemoveAt(1);
        newCard.GetComponent<HeldCard>().UpdateCard(newCardInfo);
        newCard.GetComponent<HeldCard>().DisplayInfo();
        // newCard.GetComponent<HeldCard>().ChangeCard(cardInfo);
    }
}
