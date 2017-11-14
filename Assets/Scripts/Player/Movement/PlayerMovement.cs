using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    private Rigidbody _rb;
    private InputManager _inputManager;

    [SerializeField]
    private float _movementSpeed = 5;


    void Start() {
        _inputManager = InputManager.instance;

        _rb = this.GetComponent<Rigidbody>();
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
        _rb.MovePosition(this.transform.position += (_movement * Time.deltaTime * _movementSpeed));
    }
}
