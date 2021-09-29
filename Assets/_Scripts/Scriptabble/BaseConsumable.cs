using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Consumables",menuName ="Stats/Consumables/Base",order =1)]
public class BaseConsumable : ScriptableObject
{
    public float EffectDuration => effectDuration;
    [SerializeField] private float effectDuration;
    public LayerMask EntititesAffected => entitiesAffected;
    [SerializeField] private LayerMask entitiesAffected;
}
