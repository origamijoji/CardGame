using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour {
    [SerializeField] private GameObject _blankCard; // local
    [SerializeField] private Transform playerField;

    public void DrawCard(CardInfo cardInfo) {
        var newCard = Instantiate(_blankCard);
        newCard.transform.parent = playerField;
       // newCard.GetComponent<HeldCard>().ChangeCard(cardInfo);
    }


}
