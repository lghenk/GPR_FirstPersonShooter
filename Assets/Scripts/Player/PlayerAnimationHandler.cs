using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerAnimationHandler : NetworkBehaviour {

    [SerializeField]
    private Animator _animController;
    private FirstPersonController _fpc;

    enum _direction { // DO NOT CHANGE THE ORDER OF THESE OR IT SHALL SCREW UP THE ANIMATIONS
        forward,
        right,
        back,
        left
    }

    // Use this for initialization
    void Start () {
        if(!isLocalPlayer)
            Destroy(this);

        _fpc = GetComponent<FirstPersonController>();
	}
	
	// Update is called once per frame
	void Update () {
        bool _isMoving = false;

		if(InputManager.instance.IsKeyDown(KeyCode.W)) {
            _isMoving = true;
            _animController.SetInteger("Direction", (int)_direction.forward);
        } else if (InputManager.instance.IsKeyDown(KeyCode.D)) {
            _isMoving = true;
            _animController.SetInteger("Direction", (int)_direction.right);
        } else if (InputManager.instance.IsKeyDown(KeyCode.S)) {
            _isMoving = true;
            _animController.SetInteger("Direction", (int)_direction.back);
        } else if (InputManager.instance.IsKeyDown(KeyCode.A)) {
            _isMoving = true;
            _animController.SetInteger("Direction", (int)_direction.left);
        }

        if(_isMoving && _fpc.IsRunning()) {
            _animController.SetBool("Running", true);
            _animController.SetBool("Walking", false);
        } else if (_isMoving && !_fpc.IsRunning()) {
            _animController.SetBool("Running", false);
            _animController.SetBool("Walking", true);
        } else {
            _animController.SetBool("Running", false);
            _animController.SetBool("Walking", false);
        }
	}
}
