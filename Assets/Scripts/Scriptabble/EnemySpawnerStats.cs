using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemySpawnerStats", menuName = "Stats/Spawners/EnemySpawnerStats", order = 0)]
public class EnemySpawnerStats : ScriptableObject
{
    public float SpawnRate => spawnRate;
    [SerializeField] private float spawnRate;
    public float MaxSpawns => maxSpawns;
    [SerializeField] private float maxSpawns;
    public float DistanceToActivate => distanceToActivate;
    [SerializeField] private float distanceToActivate;
}
