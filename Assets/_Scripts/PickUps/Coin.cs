using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coin : BasePickUps
{
    public static event Action OnScore;
    public override void DoEffect(GameObject target)
    {
       OnScore.Invoke();
        Destroy(gameObject);
    }
}
