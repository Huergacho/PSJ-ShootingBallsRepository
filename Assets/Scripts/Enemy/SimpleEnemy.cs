using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : BaseEnemy
{
    public override void Update()
    {
        base.Update();
        Shoot();
    }
    public override void Move()
    {
        transform.LookAt(followTarget.transform);
        transform.position = transform.forward * speed * Time.deltaTime;
        
    }
    
}
