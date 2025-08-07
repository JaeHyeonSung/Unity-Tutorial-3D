using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    List<IObserver> Observers
    {
        get;
        set;
    }

    void AddObserver(IObserver observer);

    void RemoveObserver(IObserver observer);

    void NotifyObservers();
}