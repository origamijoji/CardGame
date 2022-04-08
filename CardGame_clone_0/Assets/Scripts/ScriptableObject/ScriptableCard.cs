using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

// This script is for ease of creating new cards.
public class ScriptableCard : ScriptableObject {
    [Header("Flair")]
    public new string name;
    public string description;
    public Sprite art;
    //public GameObject fieldCard;

    [Header("Stats")]
    public int manaCost;

    [Header("Effects")]
    [HideInInspector] public bool hasOnPlaceAbility;
    public List<Ability> OnPlaceAbility = new List<Ability>();

    protected void OnValidate() {
        if (OnPlaceAbility.Count > 0) hasOnPlaceAbility = true;
    }
}

public enum Targets { PlayerChampion, EnemyChampion, PlayerMinions, EnemyMinions, Random, All }
public enum CardType { Minion, Spell }
public enum Effect : byte { Heal, Damage, Draw, Discard, Buff, Debuff }
public enum Race { Human, Dragon, Beast, Goblin, Orc, Elf, Dwarf }
