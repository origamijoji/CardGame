using System.Collections.Generic;
using System;

[Serializable]
public struct Ability {
    public Effect effect; // visual only
    public List<Targets> targets;
    public ScriptableAbility scriptableAbility;
}
