using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 target_Offset;
    [SerializeField] private float distanceToDetectObstacles;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (target == null)
        {
            target_Offset = transform.position - target.position;
            target = GameManager.instance.mainCharacter.transform;
        }
        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + target_Offset, 0.1f);
    
        }
    }
}