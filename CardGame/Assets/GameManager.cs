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


    public void DrawCards(int amount) {
        for(int cardsDrawn = 0; cardsDrawn < amount; cardsDrawn++) {
            // draw a card
        }
    }


    public void PlayCard(CardInfo cardInfo) {
    }


    private void Start() {


    }

}
