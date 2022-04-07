using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public abstract class Entity : NetworkBehaviour
{
    [SyncVar] int _health;
    [SyncVar] int _damage;
}
