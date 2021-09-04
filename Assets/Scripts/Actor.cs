using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof (Rigidbody))]
 public class Actor : MonoBehaviour, IDamagable,IMovable
{
    [SerializeField]private ActorStats actorStats;
    protected float speed;
    protected float currentLife;
    protected Rigidbody rb;
    public float Speed => speed;
    public float MaxSpeed => actorStats.MaxSpeed;
    public int MaxLife => actorStats.MaxLife;
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentLife = actorStats.MaxLife;
        speed = actorStats.MaxSpeed;
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
    public virtual void Update()
    {
        Move();
    }
    void OnDestroy()
    {
        Destroy(gameObject);
    }
    public virtual void OnHit()
    {

    }
}
