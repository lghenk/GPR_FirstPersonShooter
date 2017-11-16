// Created by Timo Heijne

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
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

    [Tooltip("Gun shot sound")] [SerializeField] private AudioClip _gunShotSound;
    [Tooltip("The sound when the gun reloads")] [SerializeField] private AudioClip _reloadSound;
    [Tooltip("The sound when a the player switches the gun's state (Automatic/Single)")] [SerializeField] private AudioClip _switchSound;

    private _weaponStates _weaponState = _weaponStates.automatic;

    private AudioSource _audioSource;

    private bool _isReloading = false;

    enum _weaponStates {
        single,
        automatic
    }

    enum _soundClipTypes {
        gunshot,
        reload,
        switchstate
    }

    private float _curFireCooldown;

    private Transform _ply; // Local player;
    private PlayerHealthManager _lphm; // Local Player Health Manager

    void Start() {
        Reload();
        Debug.Log("Start Called");

        _audioSource = GetComponent<AudioSource>();

        StartCoroutine(GetLocalPlayer());      
    }

    IEnumerator GetLocalPlayer() {
        yield return new WaitUntil(() => GameObject.FindGameObjectWithTag("LocalPlayer"));
        _ply = GameObject.FindGameObjectWithTag("LocalPlayer").transform;
        _lphm = _ply.GetComponent<PlayerHealthManager>();

        Debug.Log("Found required scripts on local player");
    }

    public void Shoot() {

        // 1. Check for fire rate;
        if (_curFireCooldown <= 0 && _curMagazine > 0) {
            // 2. Update fire rate cooldown
            _curFireCooldown = 1 / _maxFireRate;

            // 3. Raycast away
            RaycastHit _hit;
            Ray _ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

            if (Physics.Raycast(_ray, out _hit)) {
                Transform objectHit = _hit.transform;

                Debug.Log(objectHit.name);

                Debug.DrawRay(_ray.origin, _hit.point);

                if (objectHit.tag == "Player") {
                    if (objectHit.GetComponent<PlayerHealthManager>()) {
                        PlayerHealthManager _phm = objectHit.GetComponent<PlayerHealthManager>();
                        _phm.TakeDamage(UnityEngine.Random.Range(5, 10));
                    }
                }

                if (objectHit.tag == "Enemy") {
                    if (objectHit.GetComponent<EnemyHealth>()) {
                        EnemyHealth _eh = objectHit.GetComponent<EnemyHealth>();
                        _eh.TakeDamage(UnityEngine.Random.Range(10, 20));
                    }
                }
            }
            
            if(_ply) {
                AddToDB.instance.AddShotLog(_ply.position);
            }
                
            // 4. Remove 1 bullet from cur mag
            _curMagazine -= 1;
        }
    }

    IEnumerator ReloadTimer() {
        _isReloading = true;
        yield return new WaitForSeconds(5);
        _isReloading = false;
    }

    public void Reload() {
        int reloadAmount = _maxMagazine - _curMagazine;
        _curAmmo -= reloadAmount;

        StartCoroutine(ReloadTimer());

        if (_curAmmo < 0)
            _curAmmo = 0;

        if (_curAmmo > _maxMagazine) {
            _curMagazine = _maxMagazine;
        } else {
            _curMagazine = _curAmmo;
        }
    }

    private void Update() {

        if (!_ply || !_lphm)
            return;

        _curFireCooldown -= Time.deltaTime;

        if (_curFireCooldown <= 0 && _curMagazine > 0 && !_lphm.IsDead() && !_isReloading) {
            if (_isAutomatic && _weaponState == _weaponStates.automatic && InputManager.instance.GetLeftMouse()) {
                Shoot();
                PlayAudioClip();
            } else if (_weaponState == _weaponStates.single && InputManager.instance.GetLeftMouseDown()) {
                Shoot();
                PlayAudioClip();
            }
        }

        if (InputManager.instance.GetKeyDown(KeyCode.R) && !_lphm.IsDead() && _curAmmo > 0 && !_isReloading) {
            Reload();
            PlayAudioClip(_soundClipTypes.reload);
        }

        if (InputManager.instance.GetKeyDown(KeyCode.B) && !_lphm.IsDead()) {
            if (_isAutomatic) {
                var numberOfWeaponStates = Enum.GetValues(typeof(_weaponStates)).Length;

                _weaponState += 1;
                if ((int)_weaponState == numberOfWeaponStates) _weaponState = 0;
                Debug.Log("Switched to " + Enum.GetName(typeof(_weaponStates), _weaponState));
            } else {
                _weaponState = _weaponStates.single;
            }

            PlayAudioClip(_soundClipTypes.switchstate);
        }
    }

    private void PlayAudioClip(_soundClipTypes _sct = _soundClipTypes.gunshot) {
        if(_sct == _soundClipTypes.gunshot) {
            _audioSource.clip = _gunShotSound;
        } else if(_sct == _soundClipTypes.reload) {
            _audioSource.clip = _reloadSound;
        } else if (_sct == _soundClipTypes.switchstate) {
            _audioSource.clip = _switchSound;
        }

        _audioSource.Play();
    }

    public bool CanReload() {
        return (_curAmmo > 0);
    }

    public bool CanShoot() {
        return (_curMagazine > 0);
    }
}

