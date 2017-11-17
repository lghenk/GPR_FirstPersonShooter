using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public float refreshTime = 3f;

    [SerializeField]
    private float _curRefreshTime = 0;

    // Update is called once per frame
    void Update() {
        if (_curRefreshTime >= 0) {
            _curRefreshTime -= Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (_curRefreshTime <= 0) {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "LocalPlayer") {
                PlayerHealthManager _phm = collision.gameObject.GetComponent<PlayerHealthManager>();
                if (_phm) {
                    _phm.TakeDamage(Random.Range(5, 15));
                }

                _curRefreshTime = refreshTime;
            }            
        }
    }

    void OnCollisionStay(Collision collision) {
        if (_curRefreshTime <= 0) {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "LocalPlayer") {
                PlayerHealthManager _phm = collision.gameObject.GetComponent<PlayerHealthManager>();
                if (_phm) {
                    _phm.TakeDamage(Random.Range(5, 15));
                }

                _curRefreshTime = refreshTime;
            }
        }
    }

}