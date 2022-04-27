using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CCGNetworkManager : NetworkManager
{
    public bool HasTwoPlayers { get; set; }
    public override void OnStartServer() {
        HasTwoPlayers = false;
        var gameManager = Instantiate(singleton.spawnPrefabs.Find(prefab => prefab.name == "GameManager"));
        NetworkServer.Spawn(gameManager);
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        //base.OnServerAddPlayer(conn);
        var spawnPoint = ReferenceManager.Instance.OpponentSpawn;
        var newPlayer = Instantiate(singleton.playerPrefab, spawnPoint);
        NetworkServer.AddPlayerForConnection(conn, newPlayer);

        if (HasTwoPlayers == false) { HasTwoPlayers = true; return; }
        var newPlayerPlayer = newPlayer.GetComponent<Player>();
        Player.LocalPlayer.SetEnemy(newPlayerPlayer);
        newPlayerPlayer.ThisTarget = Targets.EnemyChampion;
    }
}
