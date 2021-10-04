using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Actor : MonoBehaviour, IDamagable, IMovable
{
<<<<<<< HEAD:Assets/Scripts/Actor.cs
    [SerializeField] protected AnimationManager animationManager;
    [SerializeField] protected RangeWeapon rangedWeapon;
    [SerializeField] protected MeleeWeapon meeleWeapon;
    [SerializeField] protected ActorStats actorStats; //TODO, Dividir el actor stats entre vida y movimiento
=======
    [SerializeField] public AnimationManager animationManager;
    [SerializeField] protected RangeWeapon rangedWeapon;
    [SerializeField] protected MeleeWeapon meeleWeapon;
    [SerializeField] protected ActorStats actorStats;
>>>>>>> develop:Assets/_Scripts/CharacterScipts/Actor.cs
    protected float speed;
    protected float currentLife;
    protected Rigidbody rb;
    public float Speed => speed;
    public float MaxSpeed => actorStats.MaxSpeed;
    public int MaxLife => actorStats.MaxLife;
    protected Animator animator;
    protected bool isRunning;
<<<<<<< HEAD:Assets/Scripts/Actor.cs
    public bool IsRanged => isRanged;
    [SerializeField] protected bool isRanged;

=======
    [SerializeField]protected BaseWeapon equipedWeapon;
>>>>>>> develop:Assets/_Scripts/CharacterScipts/Actor.cs
    protected virtual void Start()
    {
        SetStats();
    }

    public virtual void Move()
    {
<<<<<<< HEAD:Assets/Scripts/Actor.cs
=======
        if (isRunning)
        {
        animationManager.ChangeState(AnimationManager.State.run);

        }
        else animationManager.ChangeState(AnimationManager.State.walk);
>>>>>>> develop:Assets/_Scripts/CharacterScipts/Actor.cs
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
        animationManager.ChangeState(AnimationManager.State.getHit);
    }
    public void CanSprint(bool canRun)
    {
        isRunning = canRun;
    }
    public virtual void Attack()
    {
<<<<<<< HEAD:Assets/Scripts/Actor.cs
        if (isRanged)
=======
        if (equipedWeapon.WeaponStats.IsRanged)
>>>>>>> develop:Assets/_Scripts/CharacterScipts/Actor.cs
        {
            rangedWeapon.Shoot();
        }
        else
        {
            meeleWeapon.MeleeAttack();
        }
    }
<<<<<<< HEAD:Assets/Scripts/Actor.cs
    public virtual void ChangeWeaponState(bool isUsingRangedWeapons)
    {
        isRanged = isUsingRangedWeapons;
=======
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
>>>>>>> develop:Assets/_Scripts/CharacterScipts/Actor.cs
    }
}
