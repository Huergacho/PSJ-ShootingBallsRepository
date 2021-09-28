using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="HealingPotionStats",menuName ="Stats/HealingPotion",order =1)]
public class HealingPotionStats : ScriptableObject
{
    public float HealAmount => healAmount;
    [SerializeField] private float healAmount;
}
