using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : BaseWeapon
{
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
}
