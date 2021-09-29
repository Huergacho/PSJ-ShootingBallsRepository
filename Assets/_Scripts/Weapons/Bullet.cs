using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooleable
{
    [SerializeField]private ProyectileStats proyectileStats;
    private float currentDamage;
    private float bulletCurrentSpeed;
    private float currentLifeTime;
    private GenericPool genericPool;
    private bool isDestroyed = false;
    [SerializeField]private LayerMask target;

    private void Start()
    {
        OnObjectSpawn();
        
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        bulletCurrentSpeed += Time.deltaTime;
        transform.position += transform.forward * bulletCurrentSpeed * Time.deltaTime;
        currentLifeTime = currentLifeTime - Time.deltaTime;
        if (currentLifeTime <= 0)
        {
            if (!isDestroyed)
            {
                DestroyActions();

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((target & 1 << other.gameObject.layer) != 0)
        {
            TakeDamageCommand damageCommand = new TakeDamageCommand(other.gameObject.GetComponent<Actor>(),proyectileStats.ProyectileDamage);
            damageCommand.Do();
            if (!isDestroyed)
            {
        print(other.name + "Entro en colision");
                DestroyActions();

            }
        }
    }    
    private void OnCollisionEnter(Collision other)
    {
        if ((target & 1 << other.gameObject.layer) != 0)
        {
            TakeDamageCommand damageCommand = new TakeDamageCommand(other.gameObject.GetComponent<Actor>(),proyectileStats.ProyectileDamage);
            damageCommand.Do();
            if (!isDestroyed)
            { 
                DestroyActions();

            }
        }
        else
        {
            if (!isDestroyed)
            {

            DestroyActions();
            }
        }
    }
    private void DestroyActions()
    {
        isDestroyed = true;
        if (isDestroyed)
        {
            var particles = genericPool.SpawnFromPool(proyectileStats.ProyectileParticlesTag, transform.position, transform.rotation);
            particles.GetComponent<ParticleSystem>().Play();
            if (!particles.GetComponent<ParticleSystem>().isEmitting)
            {
                particles.SetActive(false);
            }
            gameObject.SetActive(false);

        }

    }
    public void OnSetValues(RangeWeapon owner)
    {
        target = ((BaseWeapon)owner).WeaponStats.TargetLayer;
        proyectileStats = owner.PoryectileStats;

        isDestroyed = false;
    }

    public void OnObjectSpawn()
    {
        genericPool = GenericPool.Instance;
        currentLifeTime = proyectileStats.ProyectileLifeTime;
        bulletCurrentSpeed = proyectileStats.ProyectileSpeed;
    }
}
