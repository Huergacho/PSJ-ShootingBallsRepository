using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public abstract class Actor : MonoBehaviour, IDamagable, IMovable
{
    [SerializeField] public AnimationManager animationManager;
    [SerializeField] protected RangeWeapon rangedWeapon;
    [SerializeField] protected MeleeWeapon meeleWeapon;
    [SerializeField] protected ActorStats actorStats;
    protected float speed;
    protected float currentLife;
    protected Rigidbody rb;
    public float Speed => speed;
    public float MaxSpeed => actorStats.MaxSpeed;
    public int MaxLife => actorStats.MaxLife;
    protected Animator animator;
    protected bool isRunning;
    [SerializeField]protected BaseWeapon equipedWeapon;
    protected virtual void Start()
    {
        SetStats();
    }

    public virtual void Move()
    {
        if (isRunning)
        {
        animationManager.ChangeState(AnimationManager.State.run);

        }
        else animationManager.ChangeState(AnimationManager.State.walk);
    }

    public virtual void TakeDamage(float damage)
    {
        currentLife = currentLife - damage;
        OnHit();
        if (currentLife <= 0)
        {
            Respawn();
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
    protected virtual void OnHit()
    {
        
    }
    public void CanSprint(bool canRun)
    {
        isRunning = canRun;
    }
    public virtual void Attack()
    {
        if (equipedWeapon.WeaponStats.IsRanged)
        {
            rangedWeapon.Shoot();
        }
        else
        {
            meeleWeapon.MeleeAttack();
        }
    }
    public void MakeAttackAnimation()
    {
        if (animationManager != null)
        {
            animationManager.ChangeState(AnimationManager.State.attack);
        }

    }
    protected virtual void Respawn()
    {
        SetStats();
    }
    private void SetStats()
    {
        if (rangedWeapon != null)
        {
            equipedWeapon = rangedWeapon;
        }
        else
        {
            equipedWeapon = meeleWeapon;
        }
        animator = GetComponent<Animator>();
        animationManager = GetComponent<AnimationManager>();
        rb = GetComponent<Rigidbody>();
        currentLife = actorStats.MaxLife;
        speed = MaxSpeed;
    }
}
