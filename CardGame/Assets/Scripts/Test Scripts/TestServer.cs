using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TestServer : NetworkBehaviour
{
    [SyncVar] public readonly int player1health;
    [SyncVar] public readonly int player2health;
    public GameObject[] playersConnected = new GameObject[2];
    public GameObject _localPlayer;
    public GameObject _remotePlayer;

    public void InitializePlayers(GameObject localPlayer) {
        //_localPlayer = localPlayer;
        //_remotePlayer = GameObject.Find("Player (clone)");
        playersConnected = GameObject.FindGameObjectsWithTag("Player");
    }

}
