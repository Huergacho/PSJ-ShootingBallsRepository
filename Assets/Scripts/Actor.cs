using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Actor : MonoBehaviour, IDamagable, IMovable
{
    [SerializeField] protected AnimationManager animationManager;
    [SerializeField] protected ActorStats actorStats;
    protected float speed;
    protected float currentLife;
    protected Rigidbody rb;
    public float Speed => speed;
    public float MaxSpeed => actorStats.MaxSpeed;
    public int MaxLife => actorStats.MaxLife;
    protected Animator animator;
    protected bool isRunning;
    public virtual void Start()
    {
        
        animator = GetComponent<Animator>();
        animationManager = GetComponent<AnimationManager>();
        rb = GetComponent<Rigidbody>();
        currentLife = actorStats.MaxLife;
        speed = MaxSpeed;
    }

    public virtual void Move()
    {

    }

    public virtual void TakeDamage(float damage)
    {
        currentLife = currentLife - damage;
        OnHit();
        if (currentLife <= 0)
        {
            OnDestroy();
        }
    }
    public virtual void GetHeal(float healAmount)
    {
        currentLife += currentLife + healAmount;
        if(currentLife >= actorStats.MaxLife)
        {
            currentLife = actorStats.MaxLife;
        }
    }
    protected virtual void Update()
    {
        Move();
        if (speed > MaxSpeed)
        {
            speed = MaxSpeed;
        }
    }
    void OnDestroy()
    {
        Destroy(gameObject);
    }
    protected virtual void OnHit()
    {

    }
    public void OnSprint(bool canRun)
    {
        isRunning = canRun;
    }
}
