using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;
    private Bullet type = null;
    private float speed;
    private float lifeSpan;
    private LayerMask target;
    private new ParticleSystem particleSystem;
    private GenericPool genericPool;
    private bool isDestroyed = false;

    private void Start()
    {
        genericPool = GenericPool.Instance;
        particleSystem = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        lifeSpan = lifeSpan - Time.deltaTime;
        if (lifeSpan <= 0)
        {
            if (!isDestroyed)
            {
            OnDestroy();

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((target & 1 << other.gameObject.layer) != 0)
        {
            other.gameObject.GetComponent<Actor>()?.TakeDamage(damage);
            if (!isDestroyed)
            {
            OnDestroy();

            }
        }
    }
    private void OnDestroy()
    {
        isDestroyed = true;
        if (isDestroyed)
        {
            var particles = genericPool.SpawnFromPool("particles", transform.position, transform.rotation);
            particles.GetComponent<ParticleSystem>().Play();
        gameObject.SetActive(false);

        }

    }
    public void OnSetValues(LayerMask targetLayer, float bulletSpeed, float lifeTime, float bulletDamage)
    {
        target = targetLayer;
        speed = bulletSpeed;
        lifeSpan = lifeTime;
        damage = bulletDamage;
        isDestroyed = false;
        //TODO Recibir un el scriptable object del arma que esta casteando la bala para no duplicar valores.
    }
    private void ShowComponents(bool state)
    {
        gameObject.GetComponent<SphereCollider>().enabled = state;
        gameObject.GetComponent<MeshRenderer>().enabled = state;
        gameObject.GetComponent<TrailRenderer>().enabled = state;

    }

}
