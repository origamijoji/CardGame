using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct Ability {
    public Effect effect;
    public List<Targets> targets;
    public ScriptableAbility scriptableAbility;
}
