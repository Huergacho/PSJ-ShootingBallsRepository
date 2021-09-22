using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] spawnPositions;
    [SerializeField]private GameObject[] rooms;
    public GameObject[] Rooms => rooms;
    private int direction;
    [SerializeField] private float moveAmount;
    private float timeToSpawnRooms;
    [SerializeField]private float timeToStart = 0.25f;
    [SerializeField]private float minX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxX;
    [SerializeField] private bool canGenerate = true;
    public bool CanGenerate => canGenerate;
    [SerializeField] private LayerMask roomLayerMask;
    public static event Action<Vector3> spawnPoint;
    [SerializeField] private int randomStartingPos;
    [SerializeField] private Transform startRoom = null;
    [SerializeField] private Transform lastRoom = null;
 
    private void Start()
    {
        randomStartingPos = Random.Range(0, spawnPositions.Length);
        transform.position = spawnPositions[randomStartingPos].position;
        startRoom.position = transform.position;
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
            Vector3 newPos = new Vector3(transform.position.x + moveAmount, transform.position.y,transform.position.z);
            transform.position = newPos;
                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
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
                Vector3 newPos = new Vector3(transform.position.x - moveAmount, transform.position.y, transform.position.z);
                transform.position = newPos;
                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
                direction = Random.Range(3, 6);
            }
            else
            {
                direction = 5;
            }

        }
        else if (direction == 5) // ABAJO
        {
            if (transform.position.z > minZ)
            {
                Collider[] roomDetection = Physics.OverlapSphere(transform.position, 1, roomLayerMask);
                for (int i = 0; i > roomDetection.Length; i--)
                {
                    if(roomDetection[i].GetComponent<SpawnDungeonWalls>().type != 1 && roomDetection[i].GetComponent<SpawnDungeonWalls>().type != 3)
                    {
                        roomDetection[i].GetComponent<SpawnDungeonWalls>().RoomDestruction();
                        int randBottomRoom = Random.Range(1, 4);
                        if(randBottomRoom == 2)
                        {
                            randBottomRoom = 1;
                        }
                    }
                }
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveAmount);
                transform.position = newPos;
                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
                direction = Random.Range(1, 6);
            }
            else
            {
                canGenerate = false;
                lastRoom.position = transform.position;
                spawnPoint?.Invoke(spawnPositions[randomStartingPos].position);
            }

        }
    }
}
