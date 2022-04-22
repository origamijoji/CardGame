using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    static CardList _instance;
    public static CardList Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CardList>();
            }
            return _instance;
        }
    }

    public static Minion GetMinion(int cardID)
    {
        return minionList[cardID];
    }
    public static Spell GetSpell(int cardID)
    {
        return spellList[cardID];
    }
    public static void AddSpell(int cardID, Spell spell)
    {
        spellList.Add(cardID, spell);
    }
    public static void AddMinion(int cardID, Minion minion)
    {
        minionList.Add(cardID, minion);
    }

    public List<MinionInfo> minions = new List<MinionInfo>();
    public List<SpellInfo> spells = new List<SpellInfo>();

    public static Dictionary<int, Minion> minionList = new Dictionary<int, Minion>();
    public static Dictionary<int, Spell> spellList = new Dictionary<int, Spell>();

    private void Awake()
    {
        foreach (MinionInfo cardInfo in minions)
        {
            AddMinion(cardInfo.cardID, cardInfo.minion);
        }
        foreach (SpellInfo cardInfo in spells)
        {
            AddSpell(cardInfo.cardID, cardInfo.spell);
        }
    }
}
