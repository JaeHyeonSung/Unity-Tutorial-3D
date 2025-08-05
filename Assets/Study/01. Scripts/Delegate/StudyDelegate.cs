using UnityEngine;

public class StudyDelegate : MonoBehaviour
{

    public delegate void MyDelegate();
    public MyDelegate myDelegate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myDelegate = new MyDelegate(MethodA);
        myDelegate?.Invoke();
    }

    private void MethodA()
    {
        Debug.Log("MethodA");
    }
     
    
}
