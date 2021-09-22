using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : BaseEnemy
{
    protected override void Update()
    {
        base.Update();

    }
    public override void Move()
    {
        transform.LookAt(followTarget.transform);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    
}
