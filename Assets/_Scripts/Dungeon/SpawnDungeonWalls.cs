using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDungeonWalls : MonoBehaviour
{
    [SerializeField]private GameObject[] wallType;
    [SerializeField]private Transform[] wallsSpawn;
    [SerializeField]private float roomType;
    public float type => roomType;
    private void Start()
    {
        int rand = Random.Range(0, wallType.Length);
        foreach (var wall in wallsSpawn)
        {
        var roomInstance = Instantiate(wallType[rand],wall.position, Quaternion.identity);
            roomInstance.transform.parent = transform;
        }
    }
    public void RoomDestruction()
    {
        Destroy(gameObject);
    }
}
