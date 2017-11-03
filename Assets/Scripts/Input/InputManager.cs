using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * this class handles all the input the game needs.
 * it's basically a wrapper for input. 
 */
public class InputManager : MonoBehaviour {
    /*
     * This float allows for tighter or looser movement. It's confusing. 
     * You can further edit this in Project Settings -> Input
     */
    [SerializeField]
    private float _axisThreshhold = 0.2f;

    public static InputManager instance;
    
    void Awake() {
        if (InputManager.instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    /* 
     * functions that return values for the wasd/arrow buttons
     */
    public bool Up() {
        return Input.GetAxis(Strings.Movement.VERTICAL) > _axisThreshhold;
    }
    public bool Down() {
        return Input.GetAxis(Strings.Movement.VERTICAL) < -_axisThreshhold;
    }
    public bool Left() {
        return Input.GetAxis(Strings.Movement.HORIZONTAL) < -_axisThreshhold;
    }
    public bool Right() {
        return Input.GetAxis(Strings.Movement.HORIZONTAL) > _axisThreshhold;
    }

    /* 
     * functions that return values for the mouse position
     */
    public float GetXRot() {
        return Input.GetAxis(Strings.Movement.MOUSE_X);
    }
    public float GetYRot() {
        return -Input.GetAxis(Strings.Movement.MOUSE_Y);
    }

    public bool GetLeftMouseDown() {
        return Input.GetMouseButtonDown(0);
    }

    public bool GetLeftMouse() {
        return Input.GetMouseButton(0);
    }

    public bool GetRightMouseDown() {
        return Input.GetMouseButtonDown(1);
    }

    public bool GetRightMouse() {
        return Input.GetMouseButton(1);
    }
}
