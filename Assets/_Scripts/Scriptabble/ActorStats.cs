using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicActorStats", menuName = "Stats/Characters/BasicActorStats", order = 0)]
public class ActorStats : ScriptableObject 
{
    public float MaxSpeed => maxSpeed;
    [SerializeField] private float maxSpeed;
    public float RunSpeed => runSpeed;
    [SerializeField]private float runSpeed; 
    public int MaxLife => maxLife;
    [SerializeField] private int maxLife;

}
