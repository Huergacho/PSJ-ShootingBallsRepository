using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SpawnerStats", menuName = "Stats/Spawners/SpawnerStats", order = 0)]
public class SpawnerStats : ScriptableObject
{
    public float SpawnRate => spawnRate;
    [SerializeField] private float spawnRate;
    public float MaxSpawns => maxSpawns;
    [SerializeField] private float maxSpawns;
    public float DistanceToActivate => distanceToActivate;
    [SerializeField] private float distanceToActivate;
}
