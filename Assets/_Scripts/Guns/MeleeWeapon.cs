using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : BaseWeapon
{
    public void MeleeAttack()
    {
        if (!hasAttacked)
        {
            print ("attack");
            Collider[] hitInfo = Physics.OverlapSphere(firePoint.position, weaponStats.AttackRange, weaponStats.TargetLayer);
            foreach (var item in hitInfo)
            {
                //item.GetComponent<Actor>().TakeDamage(weaponStats.AttackDamage);
                TakeDamageCommand damageCommand = new TakeDamageCommand(item.gameObject.GetComponent<Actor>(), weaponStats.AttackDamage);
                damageCommand.Do();
                //print($"le hice{weaponStats.AttackDamage} daño a " + item.name);
            }
        }

    }
}
