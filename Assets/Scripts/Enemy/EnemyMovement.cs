using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    private Transform player;
    private Transform enemy;
    private NavMeshAgent nav;
    private float _dist;
    private float _pposX;
    private float _pposY;
    private float _rotDist;
    private float _rotSpeed;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = gameObject.transform;
        nav = GetComponent<NavMeshAgent>();
        nav.speed = 2;
        _pposX = player.position.x;
        _pposY = player.position.y;
        _rotDist = Random.Range(15, 20);
        _rotSpeed = Random.Range(-20, 20);
        nav.SetDestination(player.position);
    }

    void Update() {
        _dist = Vector3.Distance(player.position, gameObject.transform.position);
        nav.SetDestination(player.position);
        enemy.LookAt(player.position);
        if (_dist <= _rotDist) {
            nav.isStopped = true;
            enemy.RotateAround(player.transform.position, player.transform.up, _rotSpeed * Time.deltaTime);
        } else {
            nav.isStopped = false;
        }

    }
}
