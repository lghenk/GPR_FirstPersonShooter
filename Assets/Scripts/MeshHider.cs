using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MeshHider : NetworkBehaviour {

    public string[] objectNames;

    void Start() {
        if (!isLocalPlayer)
            return;

        for (int i = 0; i < objectNames.Length; i++) {
            Transform trans = transform.parent.Find(objectNames[i]);
            if (trans) {
                trans.gameObject.layer = 8;
            }
        }
    }
}
