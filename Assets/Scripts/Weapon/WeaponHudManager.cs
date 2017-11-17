using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class WeaponHudManager : MonoBehaviour {

    public Text ammo;
    public Text magazine;
    private BaseGun _weapon;

	// Use this for initialization
	void Start () {
        _weapon = GetComponent<BaseGun>();
	}
	
	// Update is called once per frame
	void Update () {
        ammo.text = _weapon.GetAmmoCount().ToString();
        magazine.text = _weapon.GetMagazine().ToString();
	}
}
