using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    int MaxLife { get; }

    void TakeDamage(float damage);
}
