using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristals : BasePickUps
{
    [SerializeField] private GameObject cristalToReplace;
    public override void DoEffect(GameObject target)
    {
        base.DoEffect(target);
        transform.position = cristalToReplace.transform.position;
        Destroy(cristalToReplace);
    }
}
