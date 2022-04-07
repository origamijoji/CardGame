using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class OnStartGame : NetworkBehaviour
{
    public GameObject _gameManager;

    public override void OnStartServer() {
        base.OnStartServer();
        SpawnGameManager();
    }

    private void SpawnGameManager() {
        var gameManager = Instantiate(_gameManager);
        NetworkServer.Spawn(gameManager);
    }
}
