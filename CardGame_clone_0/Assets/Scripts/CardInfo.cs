using System;
using UnityEngine;
using Mirror;
using System.Collections.Generic;

[Serializable]
public struct CardInfo {
    public string cardID;
    public int amount;

    public CardInfo(ScriptableCard data, int amount = 1) {
        cardID = data.CardID;
        this.amount = amount;
    }

    public ScriptableCard data {
        get { return ScriptableCard.Cache[cardID]; }
    }

    public Sprite image => data.art;
    public string name => data.name;
    public string cost => data.manaCost.ToString();
    public string description => data.description;

    public List<Targets> acceptableTargets => ((Minion)data).acceptableTargets;
}

// Card List
public class SyncListCard : SyncList<CardInfo> { }