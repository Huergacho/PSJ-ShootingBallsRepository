using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool doorOpen;
    [SerializeField] private float index;
    private void Start()
    {
    }
    private void Update()
    {
        if(doorOpen== true)
        {
            gameObject.SetActive(false);
        }
        if(doorOpen == false)
        {
            gameObject.SetActive(true);
        }
    }
    public void ChangeDoorState(bool isDoorOpen)
    {
        doorOpen = isDoorOpen;
    }
}
