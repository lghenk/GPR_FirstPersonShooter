using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    private Transform _player;
    private Transform _enemy;
    private NavMeshAgent _nav;

    void Start() {
        GetNewTarget();

        _enemy = gameObject.transform;
        _nav = GetComponent<NavMeshAgent>();
        //_nav.speed = Random.Range(2, 4);
        Debug.Log("ok");
    }

    void Update() {
        if(_player == null) 
            GetNewTarget();

        _nav.SetDestination(_player.position);
        _enemy.LookAt(_player.position);
    }

    void GetNewTarget() {
        GameObject[] players = GameObject.FindGameObjectsWithTag("LocalPlayer");
        GameObject[] globalPlayers = GameObject.FindGameObjectsWithTag("Player");

        players.Concat(globalPlayers);

        _player = players[Random.Range(0, players.Length - 1)].GetComponent<Transform>();
    }
}
