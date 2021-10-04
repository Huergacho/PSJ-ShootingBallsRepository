using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TrapStats", menuName = "Stats/Traps/Base", order = 0)]

public class TrapStats : ScriptableObject
{
    public float Damage => damage;
    [SerializeField] private float damage;
    public float ActivationSpeed => activationSpeed;
    [SerializeField] private float activationSpeed;
    public LayerMask AffectedLayers => affectedLayers;
    [SerializeField] private LayerMask affectedLayers;
}
