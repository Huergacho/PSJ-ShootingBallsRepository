using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : BasePickUps
{
    [SerializeField] private int maxBulletsToGive;
    public override void DoEffect(GameObject target)
    {
        base.DoEffect(target);
        var targetGun = target.GetComponentInChildren<RangeWeapon>();
        targetGun.SetBullets(maxBulletsToGive, true);
        OnDestroy();
    }
}
