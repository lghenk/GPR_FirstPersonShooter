using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public float spawnTime = 5f;
    public GameObject enemy;
    public Transform[] spawnPoints;

    void Start() {
       InvokeRepeating("Spawn",spawnTime, spawnTime); 
    }

    void Spawn() {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

}
