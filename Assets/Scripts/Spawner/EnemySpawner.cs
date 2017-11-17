using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


public class EnemySpawner : NetworkBehaviour {
    public float spawnTime = 5f;
    public GameObject enemy;
    public Transform[] spawnPoints;

    public override void OnStartServer() {
        StartCoroutine("WaitForPlayers");
    }

    void Spawner() {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        GameObject go = (GameObject)Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        NetworkServer.Spawn(go);
    }

    IEnumerator WaitForPlayers() {
        yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("LocalPlayer").Length > 0 || GameObject.FindGameObjectsWithTag("Player").Length > 0);
        Spawning();
    }

    void Spawning() {
        InvokeRepeating("Spawner", spawnTime, spawnTime);
    }
}
