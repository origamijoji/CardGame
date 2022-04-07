using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Draw", menuName = "Ability/New Draw or Discard")]
public class DrawAbility : ScriptableAbility
{
    public override void Cast(Entity target) {
        base.Cast(target);
    }
}
