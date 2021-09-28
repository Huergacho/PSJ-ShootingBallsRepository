using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : BasePickUps
{
    [SerializeField] private HealingPotionStats healingStats;
    private float healAmount => healingStats.HealAmount;
    public override void DoEffect(GameObject target)
    {
      var targetActor = target.GetComponent<Actor>();
        targetActor.GetHeal(healAmount);
        OnDestroy();
    }
}
