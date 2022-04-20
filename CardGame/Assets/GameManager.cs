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


    public void PlayCard(int cardID) {
        if (CardList.GetCard(cardID) is Minion minionCard) {
            var newCardPrefab = NetworkManager.singleton.spawnPrefabs.Find(prefab => prefab.name == "Field Card");
            var newCard = Instantiate(newCardPrefab);
            NetworkServer.Spawn(newCard);
            newCard.GetComponent<FieldCard>().SetCard(minionCard);
            newCard.transform.SetParent(ReferenceManager.Instance.PlayerField.transform);
            newCard.transform.localScale = newCardPrefab.transform.localScale;
        }
    }

}
