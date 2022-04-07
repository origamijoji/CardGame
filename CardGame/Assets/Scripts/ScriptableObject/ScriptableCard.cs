using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

// This script is for ease of creating new cards.
public class ScriptableCard : ScriptableObject {
    [SerializeField] private string id;
    public string CardID { get { return id; } }

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


    static Dictionary<string, ScriptableCard> _cache;
    public static Dictionary<string, ScriptableCard> Cache {
        get {
            if (_cache == null) {
                ScriptableCard[] cards = Resources.LoadAll<ScriptableCard>("");
                _cache = cards.ToDictionary(card => card.CardID, card => card);
            }
            return _cache;
        }
    }

    protected void OnValidate() {
        // Get a unique identifier from the asset's unique 'Asset Path'
        if (CardID == "") {
#if UNITY_EDITOR
            string path = AssetDatabase.GetAssetPath(this);
            id = AssetDatabase.AssetPathToGUID(path);
#endif
        }

        if (OnPlaceAbility.Count > 0) hasOnPlaceAbility = true;
    }
}

public enum Targets { PlayerChampion, EnemyChampion, PlayerMinions, EnemyMinions, Random, All }
public enum CardType { Minion, Spell }
public enum Effect : byte { Heal, Damage, Draw, Discard, Buff, Debuff }
public enum Race { Human, Dragon, Beast, Goblin, Orc, Elf, Dwarf }
