using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingActor : Actor
{
   [SerializeField] protected  BaseGun equipedGun;
    public virtual void Shoot()
    {
        if(equipedGun.IsShooting() == true)
        {
            animationManager.ChangeState(AnimationManager.State.shoot);       
        }
    }
}
