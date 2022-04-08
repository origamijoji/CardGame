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
    }
    public List<int> deckList = new List<int>();

    public readonly SyncList<int> _deck = new SyncList<int>();
    public readonly  SyncList<int> _hand = new  SyncList<int>();

    public void ImportDeck() {
        //_deck = deckList;
    }

    public void DrawCard() {
        var newCardInfo = deckList[1];
        var newCard = Instantiate(_blankCard);
        newCard.transform.SetParent(_playerHand);
        //_hand.Add(newCardInfo);
        deckList.RemoveAt(1);
        newCard.GetComponent<HeldCard>().DisplayInfo(1);
    }
}
