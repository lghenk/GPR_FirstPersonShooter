using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public float spawnTime = 5f;
    public GameObject enemy;
    public Transform[] spawnPoints;

    void Start() {
        StartCoroutine("WaitForPlayers");       
    }

    void Spawner() {
        Debug.Log("Spawn");
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

    IEnumerator WaitForPlayers() {
        yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("LocalPlayer").Length > 0);
        Debug.Log("players spawned");
        Spawning();
    }

    void Spawning() {
        InvokeRepeating("Spawner", spawnTime, spawnTime);
        Debug.Log("Spawning");
    }
}
