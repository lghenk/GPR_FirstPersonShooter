using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    private GameObject _cameraObject;
    private InputManager _inputManager;

    [SerializeField]
    private float _cameraSpeed = 5;

    /*
     * Initialize the required components components
     */
    void Start() {
        _cameraObject = Camera.main.gameObject;
        //check if the inputmanager is present. If it's not, add it.
        _inputManager = InputManager.instance;
    }

    void Update() {
        //rotate the entire gameobject
        this.transform.Rotate(0, _inputManager.GetXRot() * _cameraSpeed, 0);
        //rotate the camera only. 
        _cameraObject.transform.Rotate(_inputManager.GetYRot() * _cameraSpeed, 0, 0);
    }
}
