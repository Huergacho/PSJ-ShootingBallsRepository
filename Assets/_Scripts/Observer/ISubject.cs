using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    List<IObserver> Observers { get; }
    void Suscribe(IObserver observer);
    void UnSuscribe(IObserver observer);
    void SendNotification();
}
