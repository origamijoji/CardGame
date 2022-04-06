using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TestServer : NetworkBehaviour
{
    public override void OnStartServer() {
        base.OnStartServer();
        Debug.Log("Server has started");
       // NetworkServer.Spawn();
    }

    public override void OnStopServer() {
        base.OnStopServer();
        Debug.Log("Server has stopped");
    }

}
