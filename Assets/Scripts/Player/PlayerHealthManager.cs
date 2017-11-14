using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class PlayerHealthManager : NetworkBehaviour
{
    public float StartingHealth = 100;
    
    [SyncVar]
    public float CurrentHealth; 
	
	public Image HealthBar;                                

	private float _TestDmg = 1;
	private float _dmg = 25;
	private float _DelayHealthDecay = 0.01f;

    private bool _isDead;
    private bool _Damaged;


    void Awake (){
        CurrentHealth = StartingHealth;

		HealthBar = GameObject.FindWithTag("Health").GetComponent<Image>();
    }

    void Update (){

		HealthBar.fillAmount = CurrentHealth/StartingHealth;

		if (Input.GetKeyDown (KeyCode.R) && !_isDead) {
			CurrentHealth -= _TestDmg;
			if (CurrentHealth <= 0){
				Death ();
			}
		}


		if (Input.GetKeyDown (KeyCode.T) && !_Damaged && !_isDead) {
			_Damaged = true;
			StartCoroutine (HealthDecay());
//			CurrentHealth -= _TestDmg;
//			if (CurrentHealth <= 0){
//				Death ();
//			}
		} 
    }

    public void TakeDamage (int amount){
        _Damaged = true;
        CurrentHealth -= amount;

		if(CurrentHealth <= 0 && !_isDead)
        {
            Death ();
        }
    }

	public IEnumerator HealthDecay () {
		for (int i = 0; i < _dmg; i++) {
				CurrentHealth -= _TestDmg;
				if (CurrentHealth <= 0) {
					Death ();
				}
			yield return new WaitForSeconds (_DelayHealthDecay);
			}
		StopCoroutine ("HealthDecay");
		_Damaged = false;
		}

 	public void Death (){ 
        _isDead = true;
		CurrentHealth = 0;
		Time.timeScale = 0;
	 // <WeaponScriptName>.enabled = false;
	}
}