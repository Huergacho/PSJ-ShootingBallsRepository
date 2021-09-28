using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePickUps : MonoBehaviour, IPickable
{
    public float EffectTime => effectDuration;
    [SerializeField] private float effectDuration;
    [SerializeField] private string entitiesAffected;
    protected void OnTriggerEnter(Collider other)
    {
        print("Colisiono");
        if (other.gameObject.layer == LayerMask.NameToLayer(entitiesAffected))
        {
            print(other.gameObject.name);
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
