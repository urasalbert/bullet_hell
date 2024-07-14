using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> spawners; 
    public GameObject enemyPrefab;
    public float spawnInterval = 2f; 
    private float nextSpawnTime;
    private GameObject parentObject;


    private void Awake()
    {
        //For better hierarchy
        parentObject = GameObject.FindWithTag("Environment");
    }
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        if (spawners.Count == 0) return;

        //Choose random spawner 
        int randomIndex = Random.Range(0, spawners.Count);
        Transform selectedSpawner = spawners[randomIndex];

        GameObject enemy = Instantiate(enemyPrefab, selectedSpawner.position, selectedSpawner.rotation, parentObject.transform);

        //Checking health manager script for debugging
        //Null Check
        EnemyHealthManager enemyLife = enemy.GetComponent<EnemyHealthManager>();
        if (enemyLife != null)
        {
            //Debug.Log("Enemy spawned with Life script.");
        }
        else
        {
            //Debug.LogError("Spawned enemy is missing the Life script.");
        }
    }
}
