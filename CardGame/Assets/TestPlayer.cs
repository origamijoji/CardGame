using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TestPlayer : NetworkBehaviour
{
    [SyncVar] bool syncTest;

    public override void OnStartClient() {
        base.OnStartClient();
        Debug.Log("Client has connected");
    }

    public override void OnStopClient() {
        base.OnStopClient();
        Debug.Log("Client has disconnected");
    }
    private void Update() {

        if(!isLocalPlayer) { return; }

        if(Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.forward * 5);
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * 5); 
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.back * 5);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * 5);
        }
    }
}
