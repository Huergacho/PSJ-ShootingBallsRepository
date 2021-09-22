using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageCommand : ICommand
{
    float damageToTake;
    IDamagable target;
    public TakeDamageCommand(IDamagable actor, float damage)
    {
        damageToTake = damage;
        target = actor;
    }
    public void Do()
    {
       target.TakeDamage(damageToTake);
    }
}
