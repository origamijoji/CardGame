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
        _playerHand = ReferenceManager.Instance.PlayerHand.transform;
        _blankCard = ReferenceManager.Instance.Card;
    }

    public List<int> deckList = new List<int>();

    public readonly SyncList<int> _deck = new SyncList<int>();
    public readonly SyncList<int> _hand = new  SyncList<int>();

    [Command]
    public void ImportDeck() {
        if (!isLocalPlayer) { return; }
        foreach(int card in deckList) {
            _deck.Add(card);
        }
    }

    [Command]
    public void DrawCard() {
        if (!isLocalPlayer) { return; }
        var newCardInfo = deckList[0];
        var newCard = Instantiate(_blankCard);
        newCard.transform.SetParent(_playerHand);
        newCard.transform.localScale = ReferenceManager.Instance.Card.transform.localScale;
        //_hand.Add(newCardInfo);
        deckList.RemoveAt(0);
        newCard.GetComponent<HeldCard>().DisplayInfo(newCardInfo);
    }
}
