using UnityEngine;

public class SingletonEx1 : MonoBehaviour
{
    public static SingletonEx1 instance;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }
}
