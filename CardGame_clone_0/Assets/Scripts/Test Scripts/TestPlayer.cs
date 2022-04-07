using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TestPlayer : NetworkBehaviour
{
    [SyncVar] public bool syncTest;

    private void Update() {

        if(!isLocalPlayer) { return; }

        if(Input.GetKey(KeyCode.W)) {
            MoveForward();
        }
        if (Input.GetKey(KeyCode.A)) {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.S)) {
            MoveBack();
        }
        if (Input.GetKey(KeyCode.D)) {
            MoveRight();
        }

        if(Input.GetKeyDown(KeyCode.X)) {
            CmdChangeSyncTest();
        }
    }
    [Command]
    private void MoveLeft() {
        transform.Translate(Vector3.left * 2);
    }
    [Command]
    private void MoveRight() {
        transform.Translate(Vector3.right * 2);
    }
    [Command]
    private void MoveForward() {
        transform.Translate(Vector3.forward * 2);
    }
    [Command]
    private void MoveBack() {
        transform.Translate(Vector3.back * 2);
    }

    [Command]
    private void CmdChangeSyncTest() {
        syncTest = !syncTest;
        Debug.Log("SyncTest set to " + syncTest);
    }
}
