using UnityEngine;
using UnityEngine.Events;

public class StudyUnityEvent : MonoBehaviour
{
    public UnityEvent onUnityEvent;


    private void Start()
    {
        onUnityEvent.AddListener(MethodA);
    }

    void MethodA()
    {

    }
}
