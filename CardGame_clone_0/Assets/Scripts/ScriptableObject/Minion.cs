using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Minion", menuName = "Card/Minion Card")]
public class Minion : ScriptableCard
{
    public int health;
    public int attack;

    [Header("Targets")]
    public List<Targets> acceptableTargets = new List<Targets>();

    [Header("Type")]
    public List<Race> race = new List<Race>();

    [Header("OnDeath")]
    public List<Ability> onDeathAbility = new List<Ability>();
    [HideInInspector] public bool hasOnDeathEffect;

    [Header("Keyword Effects")]
    public bool isKingpin;
    public bool isFeint;
    public bool isQuick;
    public bool isLethal;
    public bool isDualWield;
    public bool isMonarch;

    [Header("Field Prefab")]
    public FieldCard fieldCard;

    protected new void OnValidate() {
        base.OnValidate();
        if (onDeathAbility.Count > 0) { hasOnDeathEffect = true; }
        if (acceptableTargets.Count == 0) {
            acceptableTargets.Add(Targets.EnemyChampion);
            acceptableTargets.Add(Targets.EnemyMinions);
        }
    }
}
