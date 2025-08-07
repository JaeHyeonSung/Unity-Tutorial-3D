using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour, ISubject
{
    public List<IObserver> Observers { get; set; }

    public void AddObserver(IObserver observer)
    {
        Observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        Observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in Observers)
        {
            //observer.Notify();
        }
    }
}