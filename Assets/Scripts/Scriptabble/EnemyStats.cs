using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="EnemyStats", menuName = "Stats/Characters/Enemy/BasicEnemyStats", order = 4)]
public class EnemyStats : ScriptableObject
{
    public float DetectionDistance => detectionDistance;
    [SerializeField] private float detectionDistance;
    public float AlertTimeDuration => alertTimeDuration;
    [SerializeField] private float alertTimeDuration;
}
