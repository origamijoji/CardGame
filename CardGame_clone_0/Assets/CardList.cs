using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    static CardList _instance;
    public static CardList Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<CardList>();
            }
            return _instance;
        }
    }

    public static ScriptableCard GetCard(int cardID) {
        return cardList[cardID];
    }

    public static void AddCard(int cardID, ScriptableCard card) {
        cardList.Add(cardID, card);
    }

    public List<CardInfo> cards = new List<CardInfo>();

    public static Dictionary<int, ScriptableCard> cardList = new Dictionary<int, ScriptableCard>();

    private void Awake() {
        foreach(CardInfo cardInfo in cards) {
            AddCard(cardInfo.cardID, cardInfo.scriptableCard);
        }
    }
}
