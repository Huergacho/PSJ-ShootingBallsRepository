using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : BaseWeapon
{
    [SerializeField] private float attackRange;
    void MeleeAttack()
    {
        Collider[] hitInfo = Physics.OverlapSphere(firePoint.position, attackRange, weaponStats.TargetLayer);
        foreach (var item in hitInfo)
        {
            item.GetComponent<Actor>().TakeDamage(weaponStats.AttackDamage);
        }
    }
}
