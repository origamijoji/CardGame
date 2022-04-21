using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FieldCard : Entity
{
    [field: SerializeField] public ScriptableCard BaseCard { get; private set; }
    // add reference to original card object
    // public reference to dragattack on same prefab
    // public reference to OnHoverDescribe component on same prefab

    public void SetCard(Minion card) {
        BaseCard = card;
        _damage = card.damage;
        _health = card.health;
    }



    public override void OnDeath() {
        // if card has death ability, do it
        // otherwise, return
    }

}
