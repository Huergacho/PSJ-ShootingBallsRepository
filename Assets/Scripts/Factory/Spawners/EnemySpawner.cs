using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SpawnerStats enemySpawnerStats;
    [SerializeField] private List<BaseEnemy> instanceEnemies = new List<BaseEnemy>();
    private Spawner<BaseEnemy> enemyFactory = new Spawner<BaseEnemy>();
    private float spawnRate;
    [SerializeField] private Actor targetToFollow;

    private float currentEnemySpawnTimer;
    private void Start()
    {
        targetToFollow = GameManager.instance.mainCharacter;
        spawnRate = enemySpawnerStats.MaxSpawns;
    }
    private void Update()
    {
        if(targetToFollow != null)
        {
            CheckDistance();
            if (spawnRate > 0)
            {
                currentEnemySpawnTimer -= Time.deltaTime;
            }
        }

    }
    private void SpawnEnemy()
    {

        if (currentEnemySpawnTimer < 0f)
        {
            BaseEnemy enemyClone = enemyFactory.Create(instanceEnemies[Random.Range(0, instanceEnemies.Count)]);
            enemyClone.SetFollowTarget(targetToFollow);
            enemyClone.transform.position = new Vector3(transform.position.x * Random.Range(0, 2), transform.position.y, transform.position.z * Random.Range(0, 2));
            spawnRate--;
            currentEnemySpawnTimer = enemySpawnerStats.SpawnRate;

        }
    }
    private void CheckDistance()
    {
        var distance = Vector3.Distance(transform.position, targetToFollow.transform.position);
        if (distance <= enemySpawnerStats.DistanceToActivate)
        {
            SpawnEnemy();
        }
    }
}
