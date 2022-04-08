using System.Collections;
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


    public List<ScriptableCard> cardList = new List<ScriptableCard>();
    private void Start() {
    }

    public class LegalCard {
        public ScriptableCard Card { get; }
        public string Name { get { return Card.name; } }
    }
}
