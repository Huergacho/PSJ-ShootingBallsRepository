using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] spawnPositions;
    [SerializeField]private GameObject[] rooms;
    private int direction;
    [SerializeField] private float moveAmount;
    private float timeToSpawnRooms;
    [SerializeField]private float timeToStart = 0.25f;
    [SerializeField]private float minX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxX;
    private float maxY;
    [SerializeField] private bool canGenerate = true;
    private void Start()
    {
        int randomStartingPos = Random.Range(0, spawnPositions.Length);
        transform.position = spawnPositions[randomStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);
        direction = Random.Range(1, 6);
        
    }
    private void Update()
    {
        if (canGenerate)
        {
            if (timeToSpawnRooms <= 0)
            {
                Move();
                timeToSpawnRooms = timeToStart;
            }
            else
            {
                timeToSpawnRooms -= Time.deltaTime;
            }
        }

    }
    private void Move()
    {
        if (direction == 1 || direction == 2) // Derecha
        {
            if(transform.position.x < maxX)
            {
            Vector2 newPos = new Vector3(transform.position.x + moveAmount, transform.position.y,transform.position.z);
            transform.position = newPos;
                if(direction == 3)
                {
                    direction = 2;
                }
                else if (direction == 4)
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5;
            }
        }
        else if(direction == 3 || direction == 4) // IZQUIERDA
        {
           if( transform.position.x > minX)
            {
                Vector2 newPos = new Vector3(transform.position.x - moveAmount, transform.position.y, transform.position.z);
                transform.position = newPos;
                direction = Random.Range(3, 6);
            }
            else
            {
                direction = 5;
            }

        }
        else if (direction == 5) // ABAJO
        {
            if (transform.position.z < minZ)
            {
                Vector2 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveAmount);
                transform.position = newPos;
                direction = Random.Range(1, 6);
            }
            else
            {
                canGenerate = false;
            }

        }
       Instantiate(rooms[0], transform.position, Quaternion.identity);
    }
}
