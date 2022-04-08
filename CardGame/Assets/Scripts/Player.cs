using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : Entity {
    [SerializeField] private PlayerDeck _deck;
    public static GameObject s_gameManager;
    public GameObject enemyPlayer;

    public int MaxMana {
        get { return Mathf.Min(_currentMaxMana, _totalMaxMana); }
    }

    [SyncVar] private int _roundMana;
    [SyncVar] private int _currentMaxMana;
    [SyncVar] private int _totalMaxMana = 10;

    public override void OnDeath() {
        // opposing player wins !
    }

    public override void OnStartServer() {
        base.OnStartServer();
        if (s_gameManager = null) {
            s_gameManager = Instantiate(NetworkManager.singleton.spawnPrefabs.Find(prefab => prefab.name == "GameManager"));
            NetworkServer.Spawn(s_gameManager);
        }
    }
    public override void OnStopServer() {
        base.OnStopServer();
    }



    private void Update() {
        if(Input.GetKeyDown(KeyCode.X)) {
            _deck.DrawCard();
        }
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
