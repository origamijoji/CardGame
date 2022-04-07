using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour {
    [SerializeField] private GameObject _blankCard;
    [SerializeField] private Transform playerField;
    [SerializeField] private PlayerDeck _deck;
    public static GameObject s_gameManager;
    public int MaxMana {
        get { return Mathf.Min(_currentMaxMana, _totalMaxMana); }
    }

    [SyncVar] private int _roundMana;
    [SyncVar] private int _currentMaxMana;
    [SyncVar] private int _totalMaxMana = 10;

    [SyncVar] private int _health = 30;


    public override void OnStartClient() {
        if (!isLocalPlayer) { return; }
        base.OnStartClient();
        playerField = GameObject.Find("Player Field").transform;
    }

    public void DrawCard(CardInfo cardInfo) {
        var newCard = Instantiate(_blankCard);
        newCard.transform.parent = playerField;
       // newCard.GetComponent<HeldCard>().ChangeCard(cardInfo);
    }

    // setter methods
    [Command]
    public void IncreaseMaxMana(int mana) {
        _currentMaxMana += mana;
    }
    [Command]
    public void DecreaseMaxMana(int mana) {
        _currentMaxMana -= mana;
    }

    [Command]
    public void IncreaseRoundMana(int mana) {
        _roundMana += mana;
    }
    [Command]
    public void DecreaseRoundMana(int mana) {
        _roundMana -= mana;
    }

    [Command]
    public void IncreaseHealth(int health) {
        _health += health;
    }
    [Command]
    public void DecreaseHealth(int health) {
        _health -= health;
    }


}
