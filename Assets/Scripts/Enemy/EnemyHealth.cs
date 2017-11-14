using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyHealth : MonoBehaviour {

	public float startingHealth = 100;

	[SyncVar]
	public float currentHealth;

	private bool _isDead;

	void Awake() {
		currentHealth = startingHealth;
	}
		
	public void TakeDamage(int amount) {
		currentHealth -= amount;

		if (currentHealth <= 0 && !_isDead) {
			Death();
		}
	}
		
	public void Death() {
		_isDead = true;
		currentHealth = 0;

        // Destroy Enemmenemmuies
        Destroy(gameObject);
	}
}