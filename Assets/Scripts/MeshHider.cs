using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MeshHider : NetworkBehaviour {

    public string[] objectNames = new string[0];

    void Start() {
        if (!isLocalPlayer)
            return;

        Transform[] transforms = gameObject.GetComponentsInChildren<Transform>();

        for (int i = 0; i < objectNames.Length; i++) {
            //Transform trans = transform.Find(objectNames[i]);

            for (int j = 0; j < transforms.Length; j++) {
                if (transforms[j].name == objectNames[i]) {
                    Transform trans = transforms[j];
                    trans.gameObject.layer = LayerMask.NameToLayer("LocalPlayer");
                    foreach (Transform t in trans) {
                        t.gameObject.layer = LayerMask.NameToLayer("LocalPlayer");
                    }
                }
            }
        }
    }

    Transform FindChildRecursively(Transform obj, string name) {
        foreach (Transform child in obj.transform) {
            if (child.name == name) {
                return child;
            } else {
                return FindChildRecursively(child, name);
            }
        }

        return null;
    }
}
