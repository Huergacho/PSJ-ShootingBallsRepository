using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : Actor
{
    [SerializeField] private EnemyStats enemyStats;
    protected bool hasDetectedEnemy;
    protected float alertTime;
    [SerializeField]protected Actor followTarget;
    protected float distance;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        followTarget = GameManager.instance.mainCharacter;
    }
    // Update is called once per frame
    protected override void Update()
    {
        DetectEnemy();
        if (hasDetectedEnemy)
        {
            alertTime = alertTime + Time.deltaTime;
            if (alertTime > enemyStats.AlertTimeDuration)
            {
                hasDetectedEnemy = false;
                alertTime = 0;
            }
        }
    }
    void DetectEnemy()
    {
        Collider[] playerDetection = Physics.OverlapSphere(transform.position, enemyStats.DetectionDistance, enemyStats.FollowTargetLayerMask);
        //foreach (var item in playerDetection)
        //{
        //    hasDetectedEnemy = true;
        //    Move();
        //}
        if(playerDetection.Length >= 1)
        {
            distance = Vector3.Distance(transform.position, followTarget.transform.position);
            hasDetectedEnemy = true;
            if (distance <= enemyStats.AttackDistance)
            {
                MakeAttackAnimation();
            }
            else
            {
                Move();
            }
        }
        else
        {
            animationManager.ChangeState(AnimationManager.State.idle);
        }


        //if(followTarget != null)
        //{
        // distance = Vector3.Distance(transform.position, followTarget.transform.position);
        //    if (distance <= enemyStats.DetectionDistance && distance >= enemyStats.AttackDistance || hasDetectedEnemy)
        //    {
        //        hasDetectedEnemy = true;
        //        Move();
        //    }
        //    else if (distance <= enemyStats.AttackDistance)
        //    {
        //        MakeAttackAnimation();
        //    }

        //}
    }
    protected override void OnHit()
    {
        hasDetectedEnemy = true;
    }
    public void SetFollowTarget(Actor target)
    {
        followTarget = target;
    }
    protected override void Respawn()
    {
        base.Respawn();
        Destroy(gameObject);
    }
}
