using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class EnemyMovement : NetworkBehaviour {
    private Transform _player;
    private Transform _enemy;
    private NavMeshAgent _nav;

    void Start() {
        if (!isServer)
            return;

        GetNewTarget();

        _enemy = gameObject.transform;
        _nav = GetComponent<NavMeshAgent>();
        //_nav.speed = Random.Range(2, 4);
    }

    void Update() {
        if (!isServer)
            return;

        if(_player == null) 
            GetNewTarget();

        _nav.destination = _player.position;
        _enemy.LookAt(_player.position);
    }

    void GetNewTarget() {
        GameObject[] localPlayers = GameObject.FindGameObjectsWithTag("LocalPlayer");
        GameObject[] globalPlayers = GameObject.FindGameObjectsWithTag("Player");

        GameObject[] players = new GameObject[localPlayers.Length + globalPlayers.Length];

        localPlayers.CopyTo(players, 0);
        globalPlayers.CopyTo(players, localPlayers.Length);

        Debug.Log(localPlayers.Length + " " + globalPlayers.Length);

        Debug.Log("Players: " + players.Length);

        _player = players[Random.Range(0, players.Length)].GetComponent<Transform>();
    }
}
