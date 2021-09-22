using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,IPooleable
{
    private float damage;
    private Bullet type = null;
    private float speed;
    private float lifeSpan;
    private LayerMask target;
    private GenericPool genericPool;
    private bool isDestroyed = false;

    private void Start()
    {
        OnObjectSpawn();
    }
    private void Update()
    {
            transform.position += transform.forward * speed * Time.deltaTime;
            lifeSpan = lifeSpan - Time.deltaTime;
            if (lifeSpan <= 0)
            {
                if (!isDestroyed)
                {
                    DestroyActions();

                }
            }
        

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //        if ((target & 1 << other.gameObject.layer) != 0)
    //        {
    //      TakeDamageCommand damageCommand = new TakeDamageCommand(other.GetComponent<Actor>(), damage);
    //        damageCommand.Do();
    //            if (!isDestroyed)
    //            {
    //                DestroyActions();

    //            }
    //        }
    //}
    private void OnCollisionEnter(Collision other)
    {
        if ((target & 1 << other.gameObject.layer) != 0)
        {
            TakeDamageCommand damageCommand = new TakeDamageCommand(other.gameObject.GetComponent<Actor>(), damage);
            damageCommand.Do();
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
            var particles = genericPool.SpawnFromPool("particles", transform.position, transform.rotation);
            particles.GetComponent<ParticleSystem>().Play();
            if (!particles.GetComponent<ParticleSystem>().isEmitting)
            {
                particles.SetActive(false);
            }
            gameObject.SetActive(false);

        }

    }
    public void OnSetValues(GunStats owner)
    {
        target = owner.TargetLayer;
        speed = owner.BulletSpeed;
        lifeSpan = owner.BulletLifeSpan;
        damage = owner.ShootDamage;
        isDestroyed = false;
        //TODO Recibir un el scriptable object del arma que esta casteando la bala para no duplicar valores.
    }

    public void OnObjectSpawn()
    {
        genericPool = GenericPool.Instance;
    }
}
