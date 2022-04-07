using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public abstract class Entity : NetworkBehaviour
{
    [SyncVar] protected int _health;
    [SyncVar] public int _damage;

    public int GetDamage() {
        return _damage;
    }


    public void TakeDamage(int damage) {
        _health -= damage;
        // check if died.
        // if died, OnDeath()
    }
    public abstract void OnDeath();

}
