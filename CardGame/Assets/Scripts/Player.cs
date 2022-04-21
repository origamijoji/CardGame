using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : Entity {
    [SerializeField] private PlayerDeck _deck;
    public static Player LocalPlayer { get; private set; }
    public int PlayerNum { get; private set; }
    public GameObject enemyPlayer;


    public int MaxMana {
        get { return Mathf.Min(_currentMaxMana, _totalMaxMana); }
    }
    public int CurrentMaxMana
    {
        get => _currentMaxMana;
        set => _currentMaxMana = CurrentMaxMana;
    }
    public int Mana
    {
        get => _mana;
        set { _mana = Mana; }
    }

    [SerializeField] private int _mana;
    private int _currentMaxMana;
    private int _totalMaxMana = 10;

    public override void OnDeath() {
        // opposing player wins !
    }

    public override void OnStartLocalPlayer()
    {
        LocalPlayer = this;
        PlayerNum = (int)netId;

        //LocalPlayer.Mana = 5;
        //Debug.Log(LocalPlayer.Mana);

    }
    public override void OnStartServer()
    {
        Debug.Log("ran on server");
    }
    public override void OnStartClient()
    {
        Debug.Log("ran on client" + netId);
    }

    public void CmdResetValues()
    {
        Mana = 5;
        CurrentMaxMana = 0;
        Health = 30;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.X)) {
            _deck.DrawCard();
        }
    }

    [Command]
    public void PlayCard(int cardID) {
        if (CardList.GetCard(cardID) is Minion minionCard) {
            var newCardPrefab = NetworkManager.singleton.spawnPrefabs.Find(prefab => prefab.name == "Field Card");
            var newCard = Instantiate(newCardPrefab);
            NetworkServer.Spawn(newCard);
            newCard.GetComponent<FieldCard>().SetCard(minionCard, cardID);
            newCard.transform.SetParent(ReferenceManager.Instance.PlayerField.transform);
            newCard.transform.localScale = newCardPrefab.transform.localScale;
        }
    }

    [Command]
    public void DecreaseHealth(int health) {
        _health -= health;
    }
}
