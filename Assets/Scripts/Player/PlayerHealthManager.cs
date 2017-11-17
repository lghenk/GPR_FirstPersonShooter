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

    private Animator _animController;


    void Awake() {
        currentHealth = startingHealth;

        _healthBar = GameObject.FindWithTag("Health").GetComponent<Image>();
        _animController = transform.GetComponent<Animator>();
    }

    void OnGUI() {
        _healthBar.fillAmount = currentHealth / startingHealth;
    }

    public bool IsDead() {
        return _isDead;
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

        // Open Death Screen on player
        
        // Wait for count down
        _animController.SetBool("Dead", true);

        // Respawn on spawn
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn() {
        yield return new WaitForSecondsRealtime(5);
        currentHealth = startingHealth;
        _isDead = false;
        transform.position = new Vector3(0, 1, 0);
    }
}