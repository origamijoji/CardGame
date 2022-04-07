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

    private readonly SyncableCardList player1Deck = new SyncableCardList();
    private readonly SyncableCardList player2Deck = new SyncableCardList();

    public void DrawCards(int amount) {
        for(int cardsDrawn = 0; cardsDrawn < amount; cardsDrawn++) {
            // draw a card
        }
    }


    public void PlayCard(CardInfo cardInfo) {
       //var newFieldCard = Instantiate(cardInfo.FieldCard);
       // NetworkServer.Spawn(newFieldCard);
    }


    private void Start() {


    }

}
