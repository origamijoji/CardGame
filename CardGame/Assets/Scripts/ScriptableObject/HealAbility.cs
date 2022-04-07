using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Buff", menuName = "Ability/New Heal or Damage")]
public class HealAbility : ScriptableAbility {
    public override void Cast(Entity target) {
        base.Cast(target);
    }
}
