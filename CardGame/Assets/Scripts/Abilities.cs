using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct Ability {
    public Effect effect; // visual only
    public List<Targets> targets;
    public ScriptableAbility scriptableAbility;
}
