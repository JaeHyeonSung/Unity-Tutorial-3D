using UnityEngine;

public class ObserverListener : MonoBehaviour, IObserver
{
    public ISubject subject;
    void OnEnable()
    {
        subject.AddObserver(this);
    }
    private void OnDisable()
    {
        subject.RemoveObserver(this);
    }
    public void Notify(int score)
    {
        Debug.Log("¾Ë¸²");
    }

    
    
}
