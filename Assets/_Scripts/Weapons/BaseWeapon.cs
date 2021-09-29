using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public WeaponStats WeaponStats => weaponStats;
    [SerializeField] protected WeaponStats weaponStats;
    public Transform FirePoint => firePoint;
    [SerializeField] protected Transform firePoint;
    public float CurrentAttackTime => currentAttackTime;
    protected float currentAttackTime;
    public bool CanMakeAttack => canMakeAttack;
    protected bool canMakeAttack;
    public float WeaponAttackRate => weaponAttackRate;
    protected float weaponAttackRate;
    public bool HasAttacked => hasAttacked;
    protected bool hasAttacked;
    protected GenericPool genericPool;




    public virtual void Start()
    {
        canMakeAttack = true;
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
            if (weaponAttackRate <= 0)
            {
                weaponAttackRate = weaponStats.AttackCooldown;
                canMakeAttack = true;
                hasAttacked = false;
            }
        }
    }


}
