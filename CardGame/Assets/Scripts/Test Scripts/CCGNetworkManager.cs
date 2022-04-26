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
        var spawnPoint = ReferenceManager.Instance.OpponentSpawn;
        var newPlayer = Instantiate(singleton.playerPrefab, spawnPoint);
        newPlayer.transform.localPosition = Vector3.zero;
        newPlayer.transform.localScale = singleton.playerPrefab.transform.localScale;
        NetworkServer.AddPlayerForConnection(conn, newPlayer);

        if (HasTwoPlayers == false) { HasTwoPlayers = true; return; }
        var newPlayerComponent = newPlayer.GetComponent<Player>();
        Player.LocalPlayer.GetEnemyInfo(newPlayer.GetComponent<Player>().netIdentity);
        GameManager.Instance.ExchangePlayerInfo(Player.LocalPlayer.netIdentity);
        
    }
}
