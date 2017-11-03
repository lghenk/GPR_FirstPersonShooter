// Created by Timo Heijne

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : MonoBehaviour {

    private int _curMagazine = 10;

    [Tooltip("Number of bullets the magazine can hold")]
    [SerializeField]
    private int _maxMagazine = 10;

    [Tooltip("Number of bullets you have in your \"inventory\"")]
    [SerializeField]
    private int _curAmmo = 100;

    [Tooltip("Number of bullets the gun can handle per second")]
    [SerializeField]
    private float _maxFireRate = 10;

    [Tooltip("Bullet Speed m/s")]
    [SerializeField]
    private float _bulletSpeed = 100;

    [Tooltip("Whether the can shoot automatic (holding mouse button down)")]
    [SerializeField]
    private bool _isAutomatic = false;

    private _weaponStates _weaponState = _weaponStates.single;

    enum _weaponStates {
        single,
        burst,
        automatic
    }

    private float _curFireCooldown;

    public void shoot() {
        // 1. Check for fire rate;
        if (_curFireCooldown <= 0 && _curMagazine > 0) {
            // 2. Update fire rate cooldown
            _curFireCooldown = 1 / _maxFireRate;

            // 3. Raycast away

            // 4. Remove 1 bullet from cur mag
            _curMagazine -= 1;

        }
    }

    public void reload() {
        int reloadAmount = _maxMagazine - _curMagazine;
        _curAmmo -= reloadAmount;

        if (_curAmmo < 0)
            _curAmmo = 0;

        if (_curAmmo > _maxMagazine) {
            _curMagazine = _maxMagazine;
        } else {
            _curMagazine = _curAmmo;
        }
    }

    private void Update() {
        _curFireCooldown -= Time.deltaTime;

        if (_curFireCooldown <= 0) {
            if (_isAutomatic && _weaponState == _weaponStates.automatic && InputManager.instance.GetLeftMouse()) {
                shoot();
            } else if (_isAutomatic && _weaponState == _weaponStates.burst && InputManager.instance.GetLeftMouseDown()) {
                for (int i = 0; i < 3; i++) {
                    shoot();
                }
            } else if (_weaponState == _weaponStates.single && InputManager.instance.GetLeftMouseDown()) {
                shoot();
            }
        }       
    }
}
