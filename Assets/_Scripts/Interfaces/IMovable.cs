using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    float Speed { get;}
    float MaxSpeed { get;}

    void Move();
}
