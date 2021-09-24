using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseWeaponStats", menuName = "Stats/Weapons/Base", order = 0)]
public class WeaponStats : ScriptableObject
{
    public float AttackDamage => attackDamage;
    [SerializeField] private float attackDamage;

    public float AttackCooldown => attackCooldown;
    [SerializeField] protected float attackCooldown;
    public LayerMask TargetLayer => targetLayer;
    [SerializeField] private LayerMask targetLayer;
    public float ReloadCooldown => reloadCooldown;
    [SerializeField] protected float reloadCooldown;
    public int MaxProyectiles => maxProyectiles;
    [SerializeField] protected int maxProyectiles;

}
