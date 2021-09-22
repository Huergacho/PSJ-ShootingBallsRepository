using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class SpawnWhenEmpty : MonoBehaviour
{
    [SerializeField] private LayerMask roomLayer;
    [SerializeField] private LevelGeneration levelGeneration;
    [SerializeField] private Vector3 spawnOffset;
    //public static event Action<bool> OnLevelGenerated;

    private void Start()
    {
        //GameManager.instance.fullLevelIndicator = this;
    }
    private void Update()
    {
        bool roomDetection = Physics.CheckSphere(transform.position,1,roomLayer);
        if(roomDetection == false && levelGeneration.CanGenerate == false)
        {
            int rand = Random.Range(0, levelGeneration.Rooms.Length);
            Instantiate(levelGeneration.Rooms[rand], transform.position - spawnOffset, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (roomDetection == true && levelGeneration.CanGenerate == false)
        {
            // OnLevelGenerated.Invoke(true);
            GameManager.instance.IsLevelGenerated(true);
            Destroy(gameObject);
        }
    }
}
