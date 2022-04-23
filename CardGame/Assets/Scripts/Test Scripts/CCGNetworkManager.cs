using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CCGNetworkManager : NetworkManager
{
    public override void OnStartServer() {
        var gameManager = Instantiate(singleton.spawnPrefabs.Find(prefab => prefab.name == "GameManager"));
        NetworkServer.Spawn(gameManager);
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        var spawnPoint = ReferenceManager.Instance.OpponentSpawn;
        var newPlayer = Instantiate(singleton.playerPrefab, spawnPoint);
        NetworkServer.AddPlayerForConnection(conn, newPlayer);
    }

}
