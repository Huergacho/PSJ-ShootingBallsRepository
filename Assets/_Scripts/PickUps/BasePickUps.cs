using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BasePickUps : MonoBehaviour, IPickable
{
    
    public float EffectTime => BaseConsumable.EffectDuration;
    [SerializeField] private BaseConsumable BaseConsumable;
    [SerializeField] private ParticleSystem particles;
    protected void Update()
    {
        Collider [] col = Physics.OverlapSphere(transform.position, 6, BaseConsumable.EntititesAffected);
        if(col.Length >= 1)
        {
            particles?.Play();
        }
        else
        {
            particles?.Stop();
        }
    }
    protected void OnTriggerEnter(Collider other)
    {
        print("Colisiono");
        if ((BaseConsumable.EntititesAffected & 1 << other.gameObject.layer) != 0)
        {
            DoEffect(other.gameObject);
        }
    }
    public virtual void DoEffect(GameObject target)
    {
    }
    public virtual void OnDestroy()
    {
        Destroy(gameObject);
    }
}
