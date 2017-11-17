using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyHealth : NetworkBehaviour {

	public float startingHealth = 100;

	[SyncVar]
	public float currentHealth;

	private bool _isDead;

	void Awake() {
		currentHealth = startingHealth;
	}

    private void Update() {
        if(isServer && _isDead) {
            NetworkServer.Destroy(gameObject);
        }
    }

    public void TakeDamage(int amount) {
		currentHealth -= amount;

		if (currentHealth <= 0 && !_isDead) {
            _isDead = true;
			CmdDeath();
		}
	}

    public bool IsDead() {
        return _isDead;
    }

    [Command]
	public void CmdDeath() {
        // Destroy Enemmenemmuies
        NetworkServer.Destroy(gameObject);
    }
}