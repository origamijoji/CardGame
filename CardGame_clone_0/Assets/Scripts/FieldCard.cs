using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FieldCard : Entity
{
    [field: SerializeField] public Minion BaseCard { get; private set; }
    [field: SerializeField] public int CardID { get; private set; }
    public Sprite art;
    // add reference to original card object
    // public reference to dragattack on same prefab
    // public reference to OnHoverDescribe component on same prefab

    public void SetCard(int cardID)
    {
        var card = CardList.GetMinion(cardID);
        Debug.Log(card);
        BaseCard = card;
        CardID = cardID;
        Damage = BaseCard.damage;
        Health = BaseCard.health;
        art = BaseCard.art;
    }



    public override void OnDeath()
    {
        // if card has death ability, do it
        // otherwise, return
    }

}
