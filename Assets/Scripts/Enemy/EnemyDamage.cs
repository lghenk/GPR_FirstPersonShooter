using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public float refreshTime = 3f;

    [SerializeField]
    private float _curRefreshTime = 0;

    private PlayerHealthManager _hurtingPlayer;

    // Update is called once per frame
    void Update() {
        if (_curRefreshTime >= 0) {
            _curRefreshTime -= Time.deltaTime;
        }

        if(_hurtingPlayer != null && _curRefreshTime <= 0) {
            _hurtingPlayer.TakeDamage(Random.Range(5, 15));
            _curRefreshTime = refreshTime;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "LocalPlayer") {
            PlayerHealthManager _phm = collision.gameObject.GetComponent<PlayerHealthManager>();
            if (_phm) {
                _hurtingPlayer = _phm;
            }
        }
    }

    private void OnCollisionExit(Collision collision) {
        _hurtingPlayer = null;
    }

}