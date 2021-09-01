using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    float EffectTime { get; }
    void DoEffect(GameObject target);
}
