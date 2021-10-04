using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : BaseWeapon
{
    [SerializeField] private float attackRange;
    public void MeleeAttack()
    {
        Collider[] hitInfo = Physics.OverlapSphere(firePoint.position, attackRange, weaponStats.TargetLayer);
        foreach (var item in hitInfo)
        {
            item.GetComponent<Actor>().TakeDamage(weaponStats.AttackDamage);
            print($"le hice{weaponStats.AttackDamage} daño a " + item.name);
        }
    }
}
