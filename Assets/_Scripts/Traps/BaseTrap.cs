using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrap : MonoBehaviour
{
    [SerializeField] private TrapStats trapStats;
    [SerializeField]private bool isActive;
    private void OnTriggerStay(Collider other)
    {
        
        if (isActive)
        {
            if (other.gameObject.layer == trapStats.AffectedLayers.value)
            {
                other.gameObject.GetComponent<Actor>().TakeDamage(trapStats.Damage);
            }

        }
        
}
    private void Activated()
    {
        isActive = !isActive;
    }
}
