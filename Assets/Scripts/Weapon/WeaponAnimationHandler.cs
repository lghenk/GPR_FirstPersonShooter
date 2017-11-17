using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationHandler : MonoBehaviour {

    [SerializeField]
    private BaseGun _bg;

    private Animator _animController;

	// Use this for initialization
	void Start () {
	    _animController = transform.parent.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (InputManager.instance.GetKeyDown(KeyCode.R) && _bg.CanReload()) {
	        _animController.ResetTrigger("Shoot");
            _animController.SetTrigger("Reload");
	    }

	    if (InputManager.instance.GetLeftMouse() && _bg.CanShoot()) {
	        _animController.ResetTrigger("Reload");
            _animController.SetTrigger("Shoot");
	    }
	}
}
