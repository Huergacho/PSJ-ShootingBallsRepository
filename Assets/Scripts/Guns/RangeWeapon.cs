using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : BaseWeapon
{
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private ProyectileStats proyectileStats;
    public ProyectileStats PoryectileStats => proyectileStats;
    public int BulletsAmount => bulletsAmount;
    protected int bulletsAmount;
    protected int currentMaxBullets;


    public override void Start()
    {
        base.Start();
        genericPool = GenericPool.Instance;
        currentMaxBullets = weaponStats.MaxProyectiles;
        bulletsAmount = weaponStats.MaxProyectiles;
    }
    public override void Update()
    {
        base.Update();
        Reload();
    }
    private void Reload()
    {
        if (bulletsAmount <= 0)
        {
            canMakeAttack = false;
            currentAttackTime = currentAttackTime - Time.deltaTime;
            if (currentAttackTime <= 0)
            {
                canMakeAttack = true;
                bulletsAmount = currentMaxBullets;
                currentAttackTime = weaponStats.ReloadCooldown;
            }
        }
    }
    public virtual void SetBullets(int bulletsToSet, bool increaseBullets)
    {
        if (increaseBullets)
            currentMaxBullets += bulletsToSet;
        else currentMaxBullets = bulletsToSet;
    }
    public bool IsShooting()
    {
        return hasAttacked;
    }
    public virtual void Shoot()
    {
        particleSystem.Play();
        if (canMakeAttack)
        {

            var bulletObject = genericPool.SpawnFromPool(proyectileStats.ProyectileTag, firePoint.position, firePoint.rotation);
            var bulletComponent = bulletObject.GetComponent<Bullet>();
            bulletComponent.OnSetValues(this);
            bulletsAmount--;
            hasAttacked = true;
        }
    }

}
