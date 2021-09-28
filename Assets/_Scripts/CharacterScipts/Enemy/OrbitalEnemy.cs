using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalEnemy : BaseEnemy
{
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }
    protected override void Update()
    {
        base.Update();
        if (!hasDetectedEnemy)
        {
            transform.LookAt(followTarget.transform.position);
        }
    }
    public override void Move()
    {
        Vector3 relativePos = followTarget.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
        transform.Translate(0, 0, 3 * speed* Time.deltaTime);

    }


}
