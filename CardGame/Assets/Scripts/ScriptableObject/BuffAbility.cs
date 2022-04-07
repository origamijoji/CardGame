using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Buff", menuName = "Ability/New Buff or Debuff")]
public class BuffAbility : ScriptableAbility
{
    public override void Cast(Entity target) {
        base.Cast(target);
    }
}
