using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGrownd : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Light roomLight;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] roomDetection = Physics.OverlapSphere(transform.position, 10, layerMask);
        foreach (var item in roomDetection)
        {
            roomLight.intensity = 10;
        }

    }
}
