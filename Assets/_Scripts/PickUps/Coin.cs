using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : BasePickUps
{
    public override void DoEffect(GameObject target)
    {
        base.DoEffect(target);
        GameManager.instance.Victory();
    }
}
