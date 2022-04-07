using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TestServer : NetworkBehaviour
{
    [SyncVar] public readonly int player1health;
    [SyncVar] public readonly int player2health;
}
