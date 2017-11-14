using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class PlayerHealthManager : NetworkBehaviour {
    public float startingHealth = 100;

    [SyncVar]
    public float currentHealth;

    private Image _healthBar;

    private float _testDmg = 1;
    private float _dmg = 25;
    private float _delayHealthDecay = 0.01f;

    private bool _isDead;
    private bool _damaged;


    void Awake() {
        currentHealth = startingHealth;

        _healthBar = GameObject.FindWithTag("Health").GetComponent<Image>();
    }

    void Update() {

        _healthBar.fillAmount = currentHealth / startingHealth;

        if (Input.GetKeyDown(KeyCode.R) && !_isDead) {
            currentHealth -= _testDmg;
            if (currentHealth <= 0) {
                Death();
            }
        }


        if (Input.GetKeyDown(KeyCode.T) && !_damaged && !_isDead) {
            _damaged = true;
            StartCoroutine(HealthDecay());
            //			currentHealth -= _testDmg;
            //			if (currentHealth <= 0){
            //				Death ();
            //			}
        }
    }

    public void TakeDamage(int amount) {
        _damaged = true;
        currentHealth -= amount;

        if (currentHealth <= 0 && !_isDead) {
            Death();
        }
    }

    public IEnumerator HealthDecay() {
        for (int i = 0; i < _dmg; i++) {
            currentHealth -= _testDmg;
            if (currentHealth <= 0) {
                Death();
            }
            yield return new WaitForSeconds(_delayHealthDecay);
        }
        StopCoroutine("HealthDecay");
        _damaged = false;
    }

    public void Death() {
        _isDead = true;
        currentHealth = 0;
        Time.timeScale = 0;
        // <WeaponScriptName>.enabled = false;
    }
}