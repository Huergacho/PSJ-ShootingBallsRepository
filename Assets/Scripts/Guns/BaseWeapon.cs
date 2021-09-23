using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected GunStats weaponStats;

    public Transform FirePoint => firePoint;
    [SerializeField] protected Transform firePoint;
    public float CurrentAttackTime => currentAttackTime;
    protected float currentAttackTime;
    public bool CanMakeAttack => canMakeAttack;
    protected bool canMakeAttack;
    public int BulletsAmount => bulletsAmount;
    protected int bulletsAmount;
    protected int currentMaxBullets;
    public float WeaponAttackRate => weaponAttackRate;
    protected float weaponAttackRate;

    protected bool hasAttacked;

    [SerializeField] private ParticleSystem particleSystem;
    private GenericPool genericPool;

    public virtual void Start()
    {
        genericPool = GenericPool.Instance;
        currentMaxBullets = weaponStats.MaxProyectiles;
        bulletsAmount = weaponStats.MaxProyectiles;
        canMakeAttack = true;
    }

    public virtual void Shoot()
    {
        if (canMakeAttack)
        {
            particleSystem.Play();
            var bulletObject = genericPool.SpawnFromPool("bullet", firePoint.position, firePoint.rotation);
            var bulletComponent = bulletObject.GetComponent<Bullet>();
            bulletComponent.OnSetValues(weaponStats);
            bulletsAmount--;
            hasAttacked = true;
        }
    }
    public virtual void Update()
    {
        AttackCooldown();
  
    }

    private void AttackCooldown()
    {
        if (hasAttacked)
        {
            weaponAttackRate = weaponAttackRate - Time.deltaTime;
            canMakeAttack = false;
            if (!particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }
            if (weaponAttackRate <= 0)
            {
                weaponAttackRate = weaponStats.AttackCooldown;
                canMakeAttack = true;
                hasAttacked = false;
            }
        }
    }


}
