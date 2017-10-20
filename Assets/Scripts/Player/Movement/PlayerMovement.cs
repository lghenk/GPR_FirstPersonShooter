using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private InputManager _inputManager;
    [SerializeField]
    private float _movementSpeed = 5;


    void Start() {
        //check if the inputmanager is present. If it's not, add it.
        //I was too lazy to add it in the unity editor, and this looks pretty nice
        //copy paste from camerarotation
        if (!(_inputManager = this.GetComponent<InputManager>())) {
            _inputManager = this.gameObject.AddComponent<InputManager>();
        }
    }

    void Update() {
        Vector3 _movement = new Vector3();
        if (_inputManager.Up()) {
            _movement += this.transform.forward;
        }
        if (_inputManager.Down()) {
            _movement -= this.transform.forward;
        }
        if (_inputManager.Right()) {
            _movement += this.transform.right;
        }
        if (_inputManager.Left()) {
            _movement -= this.transform.right;
        }
        _movement.Normalize();
        this.transform.position += (_movement * Time.deltaTime * _movementSpeed);
    }
}
