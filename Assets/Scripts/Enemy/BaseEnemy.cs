using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : ShootingActor
{
    [SerializeField] private EnemyStats enemyStats;
    protected bool hasDetectedEnemy;
    protected float alertTime;
    [SerializeField]protected Actor followTarget;
    protected float distance;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }
    // Update is called once per frame
    protected override void Update()
    {
        DetectEnemy();
        if (hasDetectedEnemy)
        {
            alertTime = alertTime + Time.deltaTime;
            equipedGun?.Shoot();
            if (alertTime > enemyStats.AlertTimeDuration)
            {
                hasDetectedEnemy = false;
                alertTime = 0;
            }
        }
        OnAnimation();

    }
    void DetectEnemy()
    {
        if(followTarget != null)
        {
         distance = Vector3.Distance(transform.position, followTarget.transform.position);
            if (distance <= enemyStats.DetectionDistance || hasDetectedEnemy)
            {
                hasDetectedEnemy = true;
                Move();
            }

        }
    }
    protected override void OnHit()
    {
        hasDetectedEnemy = true;
    }
    public void SetFollowTarget(Actor target)
    {
        followTarget = target;
    }
    protected void OnAnimation()
    {
        if (hasDetectedEnemy && animationManager != null)
        {
            animationManager.ChangeState(AnimationManager.State.run);
        }
        else if (animationManager != null && !hasDetectedEnemy)
        {
            animationManager.ChangeState(AnimationManager.State.idle);
        }
    }
}
