using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : BasePickUps
{
    [SerializeField] private int levelValue;
    public override void DoEffect(GameObject target)
    {
        base.DoEffect(target);
        GameManager.instance.NextLevel(levelValue);
        target.transform.position = Vector3.zero;
    }
}
