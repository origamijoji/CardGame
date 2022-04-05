using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CardBehaviour : NetworkBehaviour
{
    private Card _card;
    private bool _isPlayed;
    private bool _canAttack;
    private int _health;
    private int _maxHealth;
    private int _attack;
    private int _manaCost;

    public void SetCard(Card card) {
        _card = card;
        _isPlayed = false;
        _canAttack = false;
        _maxHealth = card.health;
        _health = card.health;
        _attack = card.attack;
        _manaCost = card.manaCost;
    }


}
