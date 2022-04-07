using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CCGNetworkManager : NetworkManager
{
    public override void OnStartServer() {
        base.OnStartServer();
        var gameManager = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "GameManager"));
        NetworkServer.Spawn(gameManager);
    }
    public override void OnServerConnect(NetworkConnectionToClient conn) {
        //base.OnServerConnect(conn);
        //var localData = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "LocalData"));
        //NetworkServer.Spawn(localData);
    }
}
