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
        SetLethal(card.isLethal);
        SetQuick(card.isQuick);
        SetDualWield(card.isDualWield);
        SetFeint(card.isFeint);
        Damage = BaseCard.damage;
        MaxHealth = BaseCard.health;
        Health = BaseCard.health;
        gameObject.GetComponent<MinionUI>()?.SetImage();
        if (IsQuick)
        {
            ResetEntity();
        }
    }


    public override void OnDeath()
    {
        Player.LocalPlayer.DoEffect(CardID, CardType.Minion);

        Destroy(gameObject);
        foreach (Transform child in ReferenceManager.Instance.CardPreviews.transform)
        {
            Destroy(child.gameObject);
        }
    }

}
