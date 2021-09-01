using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GunStats", menuName = "Stats/Gun", order = 3)]
public class GunStats : ScriptableObject
{
    public Bullet BulletPrefab => bulletPrefab;
    [SerializeField] protected Bullet bulletPrefab;
    public float ReloadCooldown => reloadCooldown;
    [SerializeField] protected float reloadCooldown;
    public int MaxBullets => maxBullets;
    [SerializeField] protected int maxBullets;
    public float FireCooldown => fireCooldown;
    [SerializeField] protected float fireCooldown;
    public float BulletLifeSpan => bulletLifeSpan;
    [SerializeField] protected float bulletLifeSpan;
    public float BulletSpeed => bulletSpeed;
    [SerializeField] protected float bulletSpeed;
    public float ShootDamage => shootDamage;
    [SerializeField] protected float shootDamage;
    public LayerMask TargetLayer => targetLayer;
    [SerializeField] protected LayerMask targetLayer;
}
