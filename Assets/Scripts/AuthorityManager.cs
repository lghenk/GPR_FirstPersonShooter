using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AuthorityManager : NetworkBehaviour {

    public static AuthorityManager instance;

    // Use this for initialization
    void Start() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
	}

    [Command]
    public void CmdGetAuthority(GameObject go) {
        NetworkIdentity id = go.GetComponent<NetworkIdentity>();
        if (id == null) return;

        if (id.localPlayerAuthority == true && id.hasAuthority == false) {
            id.AssignClientAuthority(connectionToClient);
        }
    }

    [Command]
    public void CmdDestroyObject(GameObject go) {
        Network.Destroy(go);
        NetworkServer.UnSpawn(go);
    }
}
