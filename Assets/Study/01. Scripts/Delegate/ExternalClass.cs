using UnityEngine;

public class ExternalClass : MonoBehaviour
{
    public StudyEvent studyEvent;

    void Awake()
    {
        studyEvent = FindFirstObjectByType<StudyEvent>();
    }

    void Start()
    {
        studyEvent.onInputKey += Event1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            studyEvent.onInputKey?.Invoke();
        }
    }

    private void Event1()
    {
        Debug.Log("Event 1");
    }
}