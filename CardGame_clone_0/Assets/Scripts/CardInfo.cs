using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Sprite Art { get; private set; }
    public int ManaCost { get; private set; }
    public int Health { get; set; }
    public int Attack { get; private set; }
    public bool IsKingpin { get; set; }
    public bool IsFeint { get; set; }
    public bool IsQuick { get; set; }
    public bool IsLethal { get; set; }
    public bool IsDualWield { get; set; }

    public CardInfo() { }

    public CardInfo(ScriptableCard scriptableCard) {
        Name = scriptableCard.name;
        Description = scriptableCard.description;
        Art = scriptableCard.art;
        ManaCost = scriptableCard.manaCost;
        Health = scriptableCard.health;
        Attack = scriptableCard.attack;

        IsKingpin = scriptableCard.isKingpin;
        IsFeint = scriptableCard.isFeint;
        IsQuick = scriptableCard.isQuick;
        IsLethal = scriptableCard.isLethal;
        IsDualWield = scriptableCard.isDualWield;
    }
}
