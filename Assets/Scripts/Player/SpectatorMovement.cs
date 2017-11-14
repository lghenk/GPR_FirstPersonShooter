using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorMovement : MonoBehaviour{
    [SerializeField]
    private float movementSpeed = 5;


    void Start(){
		if (GetComponent<Rigidbody> ()) {
			GetComponent<Rigidbody> ().freezeRotation = true;
		}
    }

	void Update(){
		if (Input.GetKey(KeyCode.W)){
			transform.position = transform.position + Camera.main.transform.forward * movementSpeed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.A)){
			transform.position = transform.position + -Camera.main.transform.right * movementSpeed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.S)){
			transform.position = transform.position + -Camera.main.transform.forward * movementSpeed * Time.deltaTime;
		}
	
		if (Input.GetKey(KeyCode.D)){
			transform.position = transform.position + Camera.main.transform.right * movementSpeed * Time.deltaTime;
		}
	}
}
