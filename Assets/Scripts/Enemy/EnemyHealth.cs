using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyHealth : NetworkBehaviour {

	public float startingHealth = 100;

	[SyncVar]
	public float currentHealth;

	void Awake() {
		currentHealth = startingHealth;
	}

    public void TakeDamage(int amount) {
		currentHealth -= amount;

		if (currentHealth <= 0) {
            Destroy(gameObject);
        }

    }

    public bool IsDead() {
        return (currentHealth <= 0);
    }
}