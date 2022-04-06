using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TestPlayer : NetworkBehaviour
{

    public override void OnStartClient() {
        base.OnStartClient();
        Debug.Log("Client has connected");
    }

    public override void OnStopClient() {
        base.OnStopClient();
        Debug.Log("Client has disconnected");
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.W)) {
            transform.Translate(Vector3.forward * 5);
        }
    }
}
