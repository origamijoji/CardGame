using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : Entity {
    [SerializeField] private PlayerDeck _deck;
    public GameObject _gameManager;
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
        if (_gameManager = null) {
            _gameManager = Instantiate(NetworkManager.singleton.spawnPrefabs.Find(prefab => prefab.name == "GameManager"));
            NetworkServer.Spawn(_gameManager);
        }
    }
    public override void OnStartClient() {
        _gameManager = GameObject.Find("GameManager(Clone)");
        _gameManager.GetComponent<TestServer>().AddPlayer(gameObject);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.X)) {
            _deck.DrawCard();
        }
    }

    [Command]
    public void DecreaseMaxMana(int mana) {
        _currentMaxMana -= mana;
    }

    [Command]
    public void DecreaseRoundMana(int mana) {
        _roundMana -= mana;
    }

    [Command]
    public void DecreaseHealth(int health) {
        _health -= health;
    }
}
