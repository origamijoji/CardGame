using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerDeck : NetworkBehaviour
{
    [SerializeField] private Player _player;
    [HideInInspector] public int deckSize = 30;
    [HideInInspector] public int handSize = 7;

    public readonly SyncList<CardInfo> _deck = new SyncList<CardInfo>();
    public readonly SyncList<CardInfo> _graveyard = new SyncList<CardInfo>();
    public readonly SyncList<CardInfo> _hand = new SyncList<CardInfo>();
}
