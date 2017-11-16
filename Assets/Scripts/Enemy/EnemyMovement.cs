using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    private Transform player;
    private Transform enemy;
    private NavMeshAgent nav;

    void Start() {
        GameObject[] players = GameObject.FindGameObjectsWithTag("LocalPlayer");
        player = players[Random.Range(0, players.Length-1)].GetComponent<Transform>();
        enemy = gameObject.transform;
        nav = GetComponent<NavMeshAgent>();
        //nav.speed = Random.Range(2, 4);
        Debug.Log("ok");
    }

    void Update() {
        GameObject[] players = GameObject.FindGameObjectsWithTag("LocalPlayer");
        player = players[Random.Range(0, players.Length - 1)].GetComponent<Transform>();

        if (player == null)
            return;

        nav.SetDestination(player.position);
        enemy.LookAt(player.position);
    }
}
