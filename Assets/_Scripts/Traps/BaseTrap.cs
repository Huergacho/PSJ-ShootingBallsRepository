using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrap : MonoBehaviour
{
    [SerializeField] private TrapStats trapStats;
    [SerializeField]private bool isActive;
    private void OnTriggerEnter(Collider other)
    {
        
        if (isActive)
        {

            if ((trapStats.AffectedLayers & 1 << other.gameObject.layer) != 0)
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
