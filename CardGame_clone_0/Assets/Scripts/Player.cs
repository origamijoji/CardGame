using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : Entity {
    [SerializeField] private PlayerDeck _deck;
    public static Player LocalPlayer { get; private set; }
    [field: SerializeField] public int PlayerNum { get; private set; }
    public GameObject enemyPlayer;


    public int MaxMana {
        get { return Mathf.Min(CurrentMaxMana, _totalMaxMana); }
    }
    [SyncVar(hook = nameof(EditOpponentCards))] public int CardsHeld;
    [SyncVar] public int Mana;
    [Command] private void SetMana(int value) => Mana = value;
    [SyncVar] public int CurrentMaxMana;
    private int _totalMaxMana = 10;

    public override void OnDeath() {
        // opposing player wins !
    }

    public override void OnStartLocalPlayer()
    {
        LocalPlayer = this;
        PlayerNum = (int)netId;
        CmdResetValues();
    }

    [Command]
    public void CmdResetValues()
    {
        Mana = 0;
        CurrentMaxMana = 1;
        Health = 30;
    }

    public void EditOpponentCards(int oldValue, int newValue)
    {
    }

    public void PlayCard(int cardID, int cost)
    {
        GameManager.Instance.SpawnCard(cardID, PlayerNum);
        SetMana(Mana - cost);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.X)) {
            _deck.DrawCard();
        }
    }


    [Command]
    public void DecreaseHealth(int health) {
        Health -= health;
    }
}
