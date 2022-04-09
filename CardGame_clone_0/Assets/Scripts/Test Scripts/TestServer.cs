using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TestServer : NetworkBehaviour {
    [SyncVar] public readonly int player1health;
    [SyncVar] public readonly int player2health;
    public GameObject[] playersConnected = new GameObject[2];
    public GameObject _hostPlayer;
    public GameObject _remotePlayer;

    public void AddPlayer(GameObject player) {
        if (isServer) _hostPlayer = player;
        if (isClientOnly) _remotePlayer = player;
    }

}
