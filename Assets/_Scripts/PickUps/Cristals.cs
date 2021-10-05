using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristals : BasePickUps
{
    [SerializeField] private Door doorToOpen;
    [SerializeField] private GameObject cristalToReplace;
    public override void DoEffect(GameObject target)
    {
        base.DoEffect(target);
        doorToOpen?.ChangeDoorState(true);
        transform.position = cristalToReplace.transform.position;
        Destroy(cristalToReplace);
        enabled = false;
        var boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
    }
}
