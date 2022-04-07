using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class GameManager : NetworkBehaviour {
    static GameManager _instance;
    public static GameManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }



    private readonly SyncList<CardInfo> player1Deck = new SyncList<CardInfo>();
    private readonly SyncList<CardInfo> player2Deck = new SyncList<CardInfo>();

    [ClientRpc]
    public void RpcDrawCards(int amount) {
    }

    public void PlayCard(int player, CardInfo cardInfo) {

    }


    private void Start() {


    }

}
