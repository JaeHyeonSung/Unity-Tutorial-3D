using System;
using UnityEngine;

public class StudyEventHandler : MonoBehaviour
{
    private event EventHandler handler;

    public event EventHandler Handler
    {
        add
        {
            handler += value;
            Debug.Log($"{value.Method} 추가");
        }
        remove
        {
            handler -= value;
            Debug.Log($"{value.Method} 삭제");
        }
    }
    private void OnEnable()
    {
        Handler += MethodA;
    }

    private void OnDisable()
    {
        Handler -= MethodA;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            handler?.Invoke(this, EventArgs.Empty);
        }   
    }

    void MethodA(object o, EventArgs e)
    {
        Debug.Log("MethodA");
    }
}
