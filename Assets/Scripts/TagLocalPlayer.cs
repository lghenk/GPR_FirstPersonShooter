using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TagLocalPlayer : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	    if (isLocalPlayer) {
	        gameObject.tag = "LocalPlayer";
	    }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
