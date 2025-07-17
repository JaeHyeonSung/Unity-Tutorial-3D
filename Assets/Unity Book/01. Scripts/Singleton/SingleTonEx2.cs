using UnityEngine;

public class SingleTonEx2 : MonoBehaviour
{
    public static SingleTonEx2 instance
    {
        get; 
        private set;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
