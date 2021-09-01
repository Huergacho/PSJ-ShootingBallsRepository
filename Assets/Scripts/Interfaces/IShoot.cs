using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShoot
{
    Bullet BulletPrefab { get; }
    Transform FirePoint { get; }
    float ShootDamage { get; }

    float CurrentReloadTime { get; }

    bool CanShoot { get; }

    float ReloadCooldown { get; }

    int BulletsAmount { get; }

    int MaxBullets { get;}
    float WeaponFireRate { get; }
    float FireCooldown { get; }
    string TargetLayer { get; }

    float BulletSpeed { get; }
    float BulletLifeSpan { get; }
    bool HasShooted { get; }
    void Shoot();
}
