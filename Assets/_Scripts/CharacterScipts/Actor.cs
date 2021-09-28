using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Actor : MonoBehaviour, IDamagable, IMovable
{
    [SerializeField] public AnimationManager animationManager;
    [SerializeField] protected RangeWeapon rangedWeapon;
    [SerializeField] protected MeleeWeapon meeleWeapon;
    [SerializeField] protected ActorStats actorStats; //TODO, Dividir el actor stats entre vida y movimiento
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
        if(rangedWeapon != null)
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
}