using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GunStats", menuName = "Stats/Gun", order = 3)]
public class GunStats : ScriptableObject
{
    public Bullet ProyectilePrefab => proyectilePrefab;
    [SerializeField] protected Bullet proyectilePrefab;
    public float ReloadCooldown => reloadCooldown;
    [SerializeField] protected float reloadCooldown;
    public int MaxProyectiles => maxProyectiles;
    [SerializeField] protected int maxProyectiles;
    public float AttackCooldown => attackCooldown;
    [SerializeField] protected float attackCooldown;
    public float ProyectileLifeTime => proyectileLifeTime;
    [SerializeField] protected float proyectileLifeTime;
    public float ProyectileSpeed => proyectileSpeed;
    [SerializeField] protected float proyectileSpeed;
    public float ProyectileDamage => proyectileDamage;
    [SerializeField] protected float proyectileDamage;
    public LayerMask TargetLayer => targetLayer;
    [SerializeField] protected LayerMask targetLayer;
}
