using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FieldCard : Entity
{
    [field: SerializeField] public Minion BaseCard { get; private set; }
    [field: SerializeField] public int CardID { get; private set; }

    public void SetCard(int cardID)
    {
        var card = CardList.GetMinion(cardID);
        Debug.Log(card);
        BaseCard = card;
        CardID = cardID;
        Damage = BaseCard.damage;
        MaxHealth = BaseCard.health;
        Health = BaseCard.health;
        gameObject.GetComponent<MinionUI>()?.SetImage();
    }


    public override void OnDeath()
    {
        // if card has death ability, do it
        // otherwise, return

        Destroy(gameObject.GetComponent<OnHoverDefine>().CardPreview);
        Destroy(gameObject);
    }

}
