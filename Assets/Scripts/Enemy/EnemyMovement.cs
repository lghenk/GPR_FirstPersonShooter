using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    private Transform player;
    private Transform enemy;
    private NavMeshAgent nav;

    void Start() {
        GetNewTarget();

        enemy = gameObject.transform;
        nav = GetComponent<NavMeshAgent>();
        //nav.speed = Random.Range(2, 4);
        Debug.Log("ok");
    }

    void Update() {
        if(player == null) 
            GetNewTarget();

        nav.SetDestination(player.position);
        enemy.LookAt(player.position);
    }

    void GetNewTarget() {
        GameObject[] players = GameObject.FindGameObjectsWithTag("LocalPlayer");
        GameObject[] globalPlayers = GameObject.FindGameObjectsWithTag("Player");

        players.Concat(globalPlayers);

        player = players[Random.Range(0, players.Length - 1)].GetComponent<Transform>();
    }
}
