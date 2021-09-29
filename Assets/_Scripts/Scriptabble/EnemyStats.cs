using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="EnemyStats", menuName = "Stats/Characters/Enemy/EnemyDetectionStats", order = 4)]
public class EnemyStats : ScriptableObject
{
    public float DetectionDistance => detectionDistance;
    [SerializeField] private float detectionDistance;
    public float AlertTimeDuration => alertTimeDuration;
    [SerializeField] private float alertTimeDuration;
    public float AttackDistance => attackDistance;
    [SerializeField] private float attackDistance;
    public LayerMask FollowTargetLayerMask => followTargetLayerMask;
    [SerializeField] private LayerMask followTargetLayerMask;


}
