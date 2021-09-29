using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : BasePickUps
{
    [SerializeField] private float healAmount;
    public override void DoEffect(GameObject target)
    {
      var targetActor = target.GetComponent<Actor>();
        targetActor.GetHeal(healAmount);
        OnDestroy();
    }
}
