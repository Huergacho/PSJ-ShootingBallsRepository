using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : BasePickUps
{
    [SerializeField] private List<Door> doorList;
    

   public void ActivateDoors()
    {
        foreach (var item in doorList)
        {
            item.ChangeDoorState(true);
        }
    }

}
