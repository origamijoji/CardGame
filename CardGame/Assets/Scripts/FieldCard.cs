using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FieldCard : Entity
{
    // add reference to original card object
    // public reference to dragattack on same prefab
    // public reference to OnHoverDescribe component on same prefab

    public void Attack(Entity target) {
        var targetEntity = target.GetComponent<Entity>();
        targetEntity.TakeDamage(_attack);
        TakeDamage(target.GetDamage());
    }

    public override OnDeath() {
        // if card has death ability, do it
        // otherwise, return
    }

}
