using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleEnemy : BaseEnemy
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();

    }
    public override void Move()
    {
        base.Move();
        transform.LookAt(followTarget.transform);
        transform.position += transform.forward * speed * Time.deltaTime;
       
    }

}